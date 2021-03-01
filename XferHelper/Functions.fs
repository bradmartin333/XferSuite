﻿namespace XferHelper

open MathNet.Numerics.Statistics
open System.IO
open System

module Stats =
    let median (data:float[]) =
        Statistics.Median(data)

    let stdDev (data:float[]) =
        Statistics.PopulationStandardDeviation(data)

module Metro =
    [<Literal>] 
    let CSVschema = "Inline_Trial\tImage_Number\tX_Position\tY_Position\tTarget_RR\tTarget_RC\tTarget_R\tTarget_C\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error"

    [<Literal>] 
    let CSVschemaSingle = "Inline_Trial\tImage_Number\tX_Position\tY_Position\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error"

    let mutable single:bool = false

    let verify (path:string) =
        let data = File.ReadAllLines path

        if data.Length < 2 then
            0 //Insufficient Data/Empty File
        else
            if data.[0] = CSVschema then
                1
            elif data.[0] = CSVschemaSingle then 
                single <- true
                2
            else
                3 //Fail

    type Position = {Num:int;
                    X:float;
                    Y:float;
                    RR:int;
                    RC:int;
                    R:int;
                    C:int;
                    SR:int;
                    SC:int;
                    XE:float;
                    YE:float;
                    Yld:string;
                    Aln:string;
                    AE:float}

    let toPosition (csvData:string) =
        let columns = csvData.Split('\t')
        let Num = int columns.[1]
        let X = float columns.[2]
        let Y = float columns.[3]
        let RR = 
            if single then 1
            else int columns.[4]
        let RC = 
            if single then 1
            else int columns.[5]
        let R = 
            if single then 1
            else int columns.[6]
        let C = 
            if single then 1
            else int columns.[7]
        let SR = 
            if single then int columns.[4]
            else int columns.[8]
        let SC = 
            if single then int columns.[5]
            else int columns.[9]
        let XE = 
            if single then float columns.[6]
            else float columns.[10]
        let YE = 
            if single then float columns.[7]
            else float columns.[11]
        let Yld = 
            if single then string columns.[8]
            else string columns.[12]
        let Aln = 
            if single then string columns.[9]
            else string columns.[13]
        let AE = 
            if single then float columns.[10]
            else float columns.[14]
        {Num = Num;
        X = X;
        Y = Y;
        RR = RR;
        RC = RC;
        R = R;
        C = C;
        SR = SR;
        SC = SC;
        XE = XE;
        YE = YE;
        Yld = Yld;
        Aln = Aln;
        AE = AE}

    let reader (path:string) =
        let data = File.ReadAllLines path
        data.[1..]
        |> Array.filter(fun x -> x <> "")
        |> Array.map toPosition

    let data (path:string) = reader path

    let XPos (data:Position[]) =
        data
        |> Array.map(fun x -> x.X)

    let YPos (data:Position[]) =
        data
        |> Array.map(fun x -> x.Y)

    let XError (data:Position[]) =
        data
        |> Array.filter(fun x -> x.Yld = " PASS " && x.Aln = " PASS ")
        |> Array.map(fun x -> x.XE)

    let YError (data:Position[]) =
        data
        |> Array.filter(fun x -> x.Yld = " PASS " && x.Aln = " PASS ")
        |> Array.map(fun x -> x.YE)

module Zed =
    type Position = {Time:System.DateTime; X:float; Y:float; H:float}
    
    let toPosition (csvData:string) =
        let columns = csvData.Split('\t')
        let Time = System.DateTime.Parse(columns.[0])
        let X = float columns.[1]
        let Y = float columns.[2]
        let mutable H = float columns.[3]
        if columns.[3] = "NaN" then H <- 0.0
        {Time = Time;
        X = X;
        Y = Y;
        H = H}

    let parse (data:string[]) =
        data
        |> Array.map toPosition

    type ScatterPosition = {Pos:float; H:float}
    
    let scatter (data:Position[], coord:bool) =
        let toScatterPosition (data:Position) =
            if coord then
                {Pos = data.X;
                H = data.H}
            else
                {Pos = data.Y;
                H = data.H}
        data 
        |> Array.map toScatterPosition
        |> Set.ofArray

    let bounds (data:Position[]) =
        [
        (data
        |> Array.map(fun x -> float(x.X))
        |> Set.ofArray
        |> Set.toList
        |> List.min);
        (data
        |> Array.map(fun x -> float(x.X))
        |> Set.ofArray
        |> Set.toList
        |> List.max);
        (data
        |> Array.map(fun x -> float(x.Y))
        |> Set.ofArray
        |> Set.toList
        |> List.min);
        (data
        |> Array.map(fun x -> float(x.Y))
        |> Set.ofArray
        |> Set.toList
        |> List.max);
        ]

module Parser = 
    type Event = {Time:DateTime; Msg:string}

    let mutable lastTime = DateTime.Today

    let toEvent (csvData:string) =
        let columns = csvData.Split('\t')
        if columns.Length <= 1 then
            {Time = lastTime; Msg = columns.[0..] |> String.concat "\t"}
        else
            try
               let Time = DateTime.Parse(columns.[0])
               lastTime <- Time
               let Msg = columns.[2..] |> String.concat "\t"
               {Time = Time; Msg = Msg}
            with
               | :? System.IndexOutOfRangeException -> {Time = lastTime; Msg = columns.[1..] |> String.concat "\t"}
               | :? System.FormatException -> {Time = lastTime; Msg = columns.[0..] |> String.concat "\t"}

    let reader (data:string[]) =
        data
        |> Array.filter(fun x -> x <> "")
        |> Array.map toEvent

    let getRuns (data:Event[]) = 
        data 
        |> Array.filter(fun x -> x.Msg.Contains "EVENT:  Program Started")

    let main (data:string[]) : Event[] =
        let d = reader data
        getRuns d
   