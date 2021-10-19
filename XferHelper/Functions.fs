namespace XferHelper

open MathNet.Numerics.Statistics
open MathNet.Numerics.Distributions
open System.IO
open System
open OxyPlot.Series

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
    type Position = {Time:System.DateTime; X:float; Y:float; Z:float}
    
    let toPosition (csvData:string) =
        let columns = csvData.Split('\t')
        let Time = System.DateTime.Parse(columns.[0])
        let X = float columns.[1]
        let Y = float columns.[2]
        let mutable Z = float columns.[3]
        if columns.[3] = "NaN" then Z <- 0.0
        {Time = Time;
        X = X;
        Y = Y;
        Z = Z}

    let getAxis (data:Position[], axis:int) =
        let output = 
            if axis = 0 then 
                data
                |> Array.map(fun x -> x.X)
            elif axis = 1 then
                data
                |> Array.map(fun x -> x.Y)
            else
                data
                |> Array.map(fun x -> x.Z)
        output

    let dataLineFit(data:Position[], axis:int) =
        let Z = getAxis(data, 2)
        let Q = getAxis(data, axis)
        MathNet.Numerics.Fit.Line(Q, Z)

    let scatterPolynomial (scatter:ScatterPoint[]) =
        let x = 
            scatter
            |> Array.map(fun x -> x.X)
        let y = 
            scatter
            |> Array.map(fun x -> x.Y)
        MathNet.Numerics.Fit.Polynomial(x, y, 3)

    let rSquared (modelScatter:OxyPlot.DataPoint[], observedScatter:ScatterPoint[]) =
        let model =
            modelScatter
            |> Array.map(fun x-> x.Y)
        let observed =
            observedScatter
            |> Array.map(fun x-> x.Y)
        System.Math.Round(MathNet.Numerics.GoodnessOfFit.RSquared(model, observed), 3)

    let bounds (data:Position[]) =
        let x = getAxis(data, 0)
        let y = getAxis(data, 1)
        let z = getAxis(data, 2)
        [| x.Minimum(); x.Maximum(); y.Minimum(); y.Maximum(); z.Minimum(); z.Maximum() |]

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

    let MakeIDs (ax:float, ay:float, 
                 bx:float, by:float, 
                 apx:float, apy:float,
                 bpx:float, bpy:float,
                 ox:float, oy:float,
                 selected:bool,
                 idx:int) : ID[] =
        [|
        for n in 0. .. by-1. do
            for m in 0. .. bx-1. do
                for l in 0. .. ay-1. do
                    for k in 0. .. ax-1. do
                        yield toID(float (k*apx+m*bpx+ox),
                            float (l*apy+n*bpy+oy),
                            int (by-n), int (bx-m), int (ay-l), int (ax-k),
                            idx, selected)
        |]

module Report =
    type State = 
        | Pass = 0 
        | Fail = 1 
        | Null = 2 
        | Misaligned = 3 
        | Other = 4

    let toState(num:int) =
        enum<State> num

    type Entry = { ImageNumber:int;
                   XCopy:int;
                   YCopy:int;
                   Name:string;
                   State:State;
                   RR:int;
                   RC:int;
                   R:int;
                   C:int;
                   X:float;
                   Y:float;}
    
    let toEntry (data:string) =
        let columns = data.Split('\t')
        let ImageNumber = int columns.[0]  
        let XCopy = int columns.[1]
        let YCopy = int columns.[2]
        let Name = string columns.[3]
        let State = 
            match string columns.[4] with
                | "Pass" -> State.Pass
                | "Fail" -> State.Fail
                | "Null" -> State.Null
                | "Misaligned" -> State.Misaligned
                | _ -> State.Other
        let RR = int columns.[5]
        let RC = int columns.[6]
        let R = int columns.[7]
        let C = int columns.[8]
        let X = float columns.[9]
        let Y = float columns.[10]
        { ImageNumber = ImageNumber;
          XCopy = XCopy;
          YCopy = YCopy;
          Name = Name;
          State = State;
          RR = RR;
          RC = RC;
          R = R;
          C = C;
          X = X;
          Y = Y;}
    
    type Bucket =
        | Buffer = 0
        | Required = 1
        | NeedOne = 2

    let toBucket(num: int) =
        enum<Bucket> num

    type Criteria = { Name:string;
                      mutable Bucket:Bucket;
                      mutable Requirements:State[]; }

    let toCriteria (name:string) =
        { Name = name;
          Bucket = Bucket.Buffer;
          Requirements = [| State.Pass |] }

    let reader (path:string) =
        let data = File.ReadAllLines path
        data
        |> Array.filter(fun x -> x <> "")
        |> Array.map toEntry

    let data (path:string) = reader path

    let getNumImages (data:Entry[]) =
        data
        |> Array.map(fun x -> x.ImageNumber)
        |> Array.toSeq
        |> Seq.distinct
        |> Seq.length

    let getNumX (data:Entry[]) =
        data
        |> Array.map(fun x -> x.XCopy)
        |> Array.toSeq
        |> Seq.distinct
        |> Seq.length

    let getNumY (data:Entry[]) =
        data
        |> Array.map(fun x -> x.YCopy)
        |> Array.toSeq
        |> Seq.distinct
        |> Seq.length

    let getFeatures (data:Entry[]) =
        data
        |> Array.map(fun x -> x.Name)
        |> Array.toSeq
        |> Seq.distinct
        |> Seq.toArray
        |> Array.map toCriteria

    let getImage (data:Entry[], num:int) =
        data
        |> Array.filter(fun x -> x.ImageNumber = num)

    let getRegion (data:Entry[]) =
        [|data.[0].RR; data.[0].RC|]

    let getCell (data:Entry[], row:int, col:int) =
        data
        |> Array.filter(fun x -> x.XCopy = row && x.YCopy = col)