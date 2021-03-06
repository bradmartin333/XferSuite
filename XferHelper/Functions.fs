﻿namespace XferHelper

open MathNet.Numerics.Statistics
open MathNet.Numerics.Distributions
open System.IO
open System

module Stats =
    let mean (data:float[]) =
        Math.Round(Statistics.Mean(data), 3)

    let median (data:float[]) =
        Math.Round(Statistics.Median(data), 3)

    let stdDev (data:float[]) =
        Statistics.StandardDeviation(data)

    let threeSig (data:float[]) =
        Math.Round(stdDev(data) * 3.0, 3)

    let normVal (data:float[], i:float) : float =
        let norm = Normal.WithMeanStdDev(mean(data), stdDev(data))
        norm.Density(i)

    let summary (data:float[]) =
        Statistics.FiveNumberSummary(data)

    let range (data:float[]) =
        data.Maximum() - data.Minimum()

module Metro =
    [<Literal>] 
    let CSVschema = "Inline_Trial\tImage_Number\tX_Position\tY_Position\tTarget_RR\tTarget_RC\tTarget_R\tTarget_C\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error"

    [<Literal>] 
    let CSVschemaAPR2021 = "Inline_Trial\tImage_Number\tX_Position\tY_Position\tTarget_RR\tTarget_RC\tTarget_R\tTarget_C\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error\tTarget_Score\tTarget_Contrast\tSource_Score\tSource_Contrast"

    [<Literal>] 
    let CSVschemaSingle = "Inline_Trial\tImage_Number\tX_Position\tY_Position\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error"

    [<Literal>] 
    let CSVschemaSingleAPR2021 = "Inline_Trial\tImage_Number\tX_Position\tY_Position\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error\tTarget_Score\tTarget_Contrast\tSource_Score\tSource_Contrast"

    let mutable single:bool = false

    let verify (path:string) =
        let data = File.ReadAllLines path

        if data.Length < 2 then
            0 //Insufficient Data/Empty File
        else
            if data.[0] = CSVschema || data.[0] = CSVschemaAPR2021 then
                1
            elif data.[0] = CSVschemaSingle || data.[0] = CSVschemaSingleAPR2021 then
                single <- true
                2
            else
                3 //Fail

    type Position = {mutable PrintNum:int;
                    Num:int;
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
                    mutable Aln:string;
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
        {PrintNum = 0;
        Num = Num;
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

    let missingData (data:Position[]) =
        data
        |> Array.partition(fun x -> x.Yld = " FAIL " && x.Aln = " NA ")

    let failData (data:Position[]) =
        data
        |> Array.partition(fun x -> x.Yld = " PASS " && x.Aln = " FAIL ")

    let prints (data:Position[]) =
        data
        |> Array.map (fun x -> x.RR, x.RC, x.R, x.C)
        |> Array.map (fun x -> string x)

    let getPrint (index:string, data:Position[]) =
        let info = index.[1..index.Length-2].Split(',')
        let RR = int info.[0]
        let RC = int info.[1]
        let R = int info.[2]
        let C = int info.[3]
        data
        |> Array.filter(fun x -> x.RR = RR && x.RC = RC && x.R = R && x.C = C)

    let XPos (data:Position[]) =
        data
        |> Array.map(fun x -> x.X)

    let YPos (data:Position[]) =
        data
        |> Array.map(fun x -> x.Y)

    let XError (data:Position[]) =
        data
        |> Array.map(fun x -> x.XE * 1e3)

    let YError (data:Position[]) =
        data
        |> Array.map(fun x -> x.YE * 1e3)

    let X3Sig (data:Position[]) =
        data
        |> Array.map(fun x -> x.XE * 1e3)
        |> Statistics.StandardDeviation
        |> fun x -> x * 3.0

    let Y3Sig (data:Position[]) =
        data
        |> Array.map(fun x -> x.YE * 1e3)
        |> Statistics.StandardDeviation
        |> fun x -> x * 3.0

    let Rescore (data:Position[], threshold:float) =
        for x in data do
            if (Math.Abs(x.XE) > threshold / 1e3 || Math.Abs(x.YE) > threshold / 1e3) then
                x.Aln <- " FAIL "
            else
                x.Aln <- " PASS "

    let NormErrorRange (data:Position[]) =
        data 
        |> Array.map(fun x -> (x.XE**2. + x.YE**2.)**0.5)

    let NextMagnitudeEntropy (data:Position[]) =
        data
        |> NormErrorRange
        |> Statistics.Entropy
        |> fun x -> x**10.

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
    let stripChars text (chars:string) =
        Array.fold (
            fun (s:string) c -> s.Replace(c.ToString(),"")
        ) text (chars.ToCharArray())

    let mutable IDX = 0

    type Event = {IDX:int; Date:DateTime; Time:TimeSpan; Category:string; Description:string; Msg:string; Data:string; Stamp:int64}

    let toEvent (csvData:string[]) =
        let Time = 
            match DateTime.TryParse(csvData.[0]) |> fst with
            | true -> DateTime.Parse(csvData.[0])
            | false -> DateTime.Today
        let Details = csvData.[2].Split(' ')
        let Category = 
            match Details.[0] with
            | "SETUP" -> Details.[0..1] |> String.concat " "
            | _ -> Details.[0]
        let Description = 
            match Details.Length with
            | 1 -> ""
            | _ -> 
                match Details.[1] with
                | "DATA:" -> Details.[2..] |> String.concat " "
                | _ -> Details.[1..] |> String.concat " "
        let Details2 = csvData.[3..] |> String.concat " "
        let CleanDetails2 = stripChars Details2 "-,.>@ "
        let Msg = 
            match System.Double.TryParse CleanDetails2 |> fst with
            | true -> ""
            | false -> Details2
        let Data =
            match Msg with
            | "" -> Details2
            | _ -> ""
        IDX <- IDX + 1
        {IDX = IDX; Date = Time.Date; Time = Time.TimeOfDay; Category = Category; Description = Description; Msg = Msg; Data = Data; Stamp = Time.Ticks}

    let reader (data:string[]) =
        data
        |> Array.filter(fun x -> x <> "" && not (x.Contains("+")) && not (x.Contains("*")))
        |> Array.map(fun x -> x.Split('\t'))
        |> Array.filter(fun x -> x.Length > 2)
        |> Array.map toEvent
  
module Sim =
    type ID = {X:float
               Y:float
               RR:int
               RC:int
               R:int
               C:int
               IDX:int
               mutable Selected:bool}
               
                override this.ToString() =
                    string this.RR + "," + string this.RC + "," + string this.R + "," + string this.C + "," + string this.IDX

    let toID (x:float,
              y:float,
              rr:int,
              rc:int,
              r:int,
              c:int,
              idx:int,
              selected:bool) =
        {X = x;
         Y = y;
         RR = rr;
         RC = rc;
         R = r;
         C = c;
         IDX = idx;
         Selected = selected}

    let SelectDevice (vals:int[], ids:ID[], sel:bool, nullRegion:bool, stampX:int, stampY:int) =
        for x in ids do
            if nullRegion then
                if x.R = vals.[2] && x.C = vals.[3] && x.IDX = vals.[4] then
                    x.Selected <- sel
            else
                if x.RR = vals.[0] && x.RC = vals.[1] && x.R < vals.[2] + stampX && x.C < vals.[3] + stampY && x.IDX = vals.[4] then
                    x.Selected <- sel

    let SelectSite (vals:int[], ids:ID[], sel:bool) =
        for x in ids do
            if x.RR = vals.[0] && x.RC = vals.[1] && x.R = vals.[2] && x.C = vals.[3] then
                x.Selected <- sel

    let MakeIDs (ax:float, ay:float, 
                 bx:float, by:float, 
                 cx:float, cy:float, 
                 apx:float, apy:float, 
                 bpx:float, bpy:float,
                 cpx:float, cpy:float,
                 ox:float, oy:float,
                 device:bool, nullRegion:bool) : ID[] =
        [|
        for n in 0. .. cy-1. do
            for m in 0. .. cx-1. do
                for l in 0. .. by-1. do
                    for k in 0. .. bx-1. do
                        let mutable idx = 1
                        if device then
                            idx <- int (((ax-1.)*(ay-1.)) + 1.)
                        for j in 0. .. ay-1. do
                            for i in 0. .. ax-1. do
                            if nullRegion then
                                yield toID(float (i*apx+k*bpx+m*cpx+ox),
                                    float (j*apy+l*bpy+n*cpy+oy),
                                    1, 1, int (cy-n), int (cx-m),
                                    idx, false)
                            else
                                yield toID(float (i*apx+k*bpx+m*cpx+ox),
                                    float (j*apy+l*bpy+n*cpy+oy),
                                    int (cy-n), int (cx-m), int (by-l), int (bx-k),
                                    idx, false)
                            if device then
                                idx <- idx - 1
        |]
