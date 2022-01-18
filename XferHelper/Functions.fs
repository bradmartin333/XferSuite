namespace XferHelper

open MathNet.Numerics.Statistics
open MathNet.Numerics.Distributions
open System.IO
open System
open OxyPlot.Series

module Stats =
    let mean (data: float []) = Math.Round(Statistics.Mean(data), 3)

    let median (data: float []) = Math.Round(Statistics.Median(data), 3)

    let stdDev (data: float []) = Statistics.StandardDeviation(data)

    let threeSig (data: float []) = Math.Round(stdDev (data) * 3.0, 3)

    let normVal (data: float []) (i: float) : float =
        let norm =
            Normal.WithMeanStdDev(mean (data), stdDev (data))

        norm.Density(i)

    let summary (data: float []) = Statistics.FiveNumberSummary(data)

    let range (data: float []) = data.Maximum() - data.Minimum()

module Metro =
    [<Literal>]
    let CSVschema =
        "Inline_Trial\tImage_Number\tX_Position\tY_Position\tTarget_RR\tTarget_RC\tTarget_R\tTarget_C\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error"

    [<Literal>]
    let CSVschemaAPR2021 =
        "Inline_Trial\tImage_Number\tX_Position\tY_Position\tTarget_RR\tTarget_RC\tTarget_R\tTarget_C\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error\tTarget_Score\tTarget_Contrast\tSource_Score\tSource_Contrast"

    [<Literal>]
    let CSVschemaSingle =
        "Inline_Trial\tImage_Number\tX_Position\tY_Position\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error"

    [<Literal>]
    let CSVschemaSingleAPR2021 =
        "Inline_Trial\tImage_Number\tX_Position\tY_Position\tStamp_R\tStamp_C\tX_error\tY_error\tYield_Measure\tAlignment_Measure\tAngle_error\tTarget_Score\tTarget_Contrast\tSource_Score\tSource_Contrast"

    let mutable single: bool = false

    let verify (path: string) =
        let data = File.ReadAllLines path

        if data.Length < 2 then
            0 //Insufficient Data/Empty File
        else if data.[0] = CSVschema
                || data.[0] = CSVschemaAPR2021 then
            1
        elif data.[0] = CSVschemaSingle
             || data.[0] = CSVschemaSingleAPR2021 then
            single <- true
            2
        else
            3 //Fail

    type Position =
        { mutable PrintNum: int
          Num: int
          X: float
          Y: float
          RR: int
          RC: int
          R: int
          C: int
          SR: int
          SC: int
          XE: float
          YE: float
          Yld: string
          mutable Aln: string
          AE: float }

    let toPosition (csvData: string) =
        let columns = csvData.Split('\t')
        let Num = int columns.[1]
        let X = float columns.[2]
        let Y = float columns.[3]
        let RR = if single then 1 else int columns.[4]
        let RC = if single then 1 else int columns.[5]
        let R = if single then 1 else int columns.[6]
        let C = if single then 1 else int columns.[7]

        let SR =
            if single then
                int columns.[4]
            else
                int columns.[8]

        let SC =
            if single then
                int columns.[5]
            else
                int columns.[9]

        let XE =
            if single then
                float columns.[6]
            else
                float columns.[10]

        let YE =
            if single then
                float columns.[7]
            else
                float columns.[11]

        let Yld =
            if single then
                string columns.[8]
            else
                string columns.[12]

        let Aln =
            if single then
                string columns.[9]
            else
                string columns.[13]

        let AE =
            if single then
                float columns.[10]
            else
                float columns.[14]

        { PrintNum = 0
          Num = Num
          X = X
          Y = Y
          RR = RR
          RC = RC
          R = R
          C = C
          SR = SR
          SC = SC
          XE = XE
          YE = YE
          Yld = Yld
          Aln = Aln
          AE = AE }

    let reader (path: string) =
        let data = File.ReadAllLines path

        data.[1..]
        |> Array.filter (fun x -> x <> "")
        |> Array.map toPosition

    let data (path: string) = reader path

    let missingData (data: Position []) =
        data
        |> Array.partition (fun x -> x.Yld = " FAIL " && x.Aln = " NA ")

    let failData (data: Position []) =
        data
        |> Array.partition (fun x -> x.Yld = " PASS " && x.Aln = " FAIL ")

    let prints (data: Position []) =
        data
        |> Array.map (fun x -> x.RR, x.RC, x.R, x.C)
        |> Array.map (fun x -> string x)

    let getPrint (index: string) (data: Position []) =
        let info = index.[1..index.Length - 2].Split(',')
        let RR = int info.[0]
        let RC = int info.[1]
        let R = int info.[2]
        let C = int info.[3]

        data
        |> Array.filter (fun x -> x.RR = RR && x.RC = RC && x.R = R && x.C = C)

    let xPos (data: Position []) = data |> Array.map (fun x -> x.X)

    let yPos (data: Position []) = data |> Array.map (fun x -> x.Y)

    let xError (data: Position []) = data |> Array.map (fun x -> x.XE * 1e3)

    let yError (data: Position []) = data |> Array.map (fun x -> x.YE * 1e3)

    let x3Sig (data: Position []) =
        data
        |> Array.map (fun x -> x.XE * 1e3)
        |> Statistics.StandardDeviation
        |> fun x -> x * 3.0

    let y3Sig (data: Position []) =
        data
        |> Array.map (fun x -> x.YE * 1e3)
        |> Statistics.StandardDeviation
        |> fun x -> x * 3.0

    let rescore (data: Position []) (threshold: float) =
        for x in data do
            if (Math.Abs(x.XE) > threshold / 1e3
                || Math.Abs(x.YE) > threshold / 1e3) then
                x.Aln <- " FAIL "
            else
                x.Aln <- " PASS "

    let normErrorRange (data: Position []) =
        data
        |> Array.map (fun x -> (x.XE ** 2. + x.YE ** 2.) ** 0.5)

    let nextMagnitudeEntropy (data: Position []) =
        data
        |> normErrorRange
        |> Statistics.Entropy
        |> fun x -> x ** 10.

    let applyFilter (filter: string []) (data: Position []) =
        data
        |> Array.filter
            (fun x ->
                let a =
                    match filter.[0] with
                    | "X" -> x.X
                    | "Y" -> x.Y
                    | "RR" -> float x.RR
                    | "RC" -> float x.RC
                    | "R" -> float x.R
                    | "C" -> float x.C
                    | "SR" -> float x.SR
                    | "SC" -> float x.SC
                    | "XE" -> x.XE
                    | "YE" -> x.YE
                    | "AE" -> x.AE
                    | _ -> float x.Num

                let b = float filter.[2]

                match filter.[1] with
                | "<" -> a < b
                | ">" -> a > b
                | "<=" -> a <= b
                | ">=" -> a >= b
                | "==" -> a = b
                | _ -> a <> b)

    let filterData (filters: string [] []) (data: Position []) =
        let mutable output = data

        for filter in filters do
            output <- applyFilter filter output

        output

module Zed =
    type Position =
        { Time: System.DateTime
          X: float
          Y: float
          Z: float }

    let toPosition (csvData: string) =
        let columns = csvData.Split('\t')
        let Time = System.DateTime.Parse(columns.[0])
        let X = float columns.[1]
        let Y = float columns.[2]
        let mutable Z = float columns.[3]
        if columns.[3] = "NaN" then Z <- 0.0
        { Time = Time; X = X; Y = Y; Z = Z }

    let getAxis (data: Position []) (axis: int) =
        let output =
            if axis = 0 then
                data |> Array.map (fun x -> x.X)
            elif axis = 1 then
                data |> Array.map (fun x -> x.Y)
            else
                data |> Array.map (fun x -> x.Z)

        output

    let dataLineFit (data: Position []) (axis: int) =
        let Z = getAxis data 2
        let Q = getAxis data axis
        MathNet.Numerics.Fit.Line(Q, Z)

    let scatterPolynomial (scatter: ScatterPoint []) =
        let x = scatter |> Array.map (fun x -> x.X)
        let y = scatter |> Array.map (fun x -> x.Y)
        MathNet.Numerics.Fit.Polynomial(x, y, 3)

    let rSquared (modelScatter: OxyPlot.DataPoint [], observedScatter: ScatterPoint []) =
        let model = modelScatter |> Array.map (fun x -> x.Y)

        let observed =
            observedScatter |> Array.map (fun x -> x.Y)

        System.Math.Round(MathNet.Numerics.GoodnessOfFit.RSquared(model, observed), 3)

    let bounds (data: Position []) =
        let x = getAxis data 0
        let y = getAxis data 1
        let z = getAxis data 2

        [| x.Minimum()
           x.Maximum()
           y.Minimum()
           y.Maximum()
           z.Minimum()
           z.Maximum() |]

    type Vec2 = { X: float; Y: float }

    let toVec2 (x: float) (y: float) = { X = x; Y = y }

    type Vec3 = { X: float; Y: float; Z: float }

    let posToVec3 (p: Position) = { X = p.X; Y = p.Y; Z = p.Z }

    let nVec3 (a: float) = { X = a; Y = a; Z = a }

    let zeroVec3 = { X = 0.; Y = 0.; Z = 0. }

    let oneVec3 = { X = 1.; Y = 1.; Z = 1. }

    let xVec3 = { X = 1.; Y = 0.; Z = 0. }

    let yVec3 = { X = 0.; Y = 1.; Z = 0. }

    let dotVec3 (a: Vec3) (b: Vec3) = a.X * b.X + a.Y * b.Y + a.Z * b.Z

    let dotOneVec3 (v: Vec3) = v.X * 1. + v.Y * 1. + v.Z * 1.

    let addVec3 (a: Vec3) (b: Vec3) =
        { X = a.X + b.X
          Y = a.Y + b.Y
          Z = a.Z + b.Z }

    let subtractVec3 (a: Vec3) (b: Vec3) =
        { X = a.X - b.X
          Y = a.Y - b.Y
          Z = a.Z - b.Z }

    let divideVec3 (a: Vec3) (b: Vec3) =
        { X = a.X / b.X
          Y = a.Y / b.Y
          Z = a.Z / b.Z }

    let multiplyVec3 (a: Vec3) (b: Vec3) =
        { X = a.X * b.X
          Y = a.Y * b.Y
          Z = a.Z * b.Z }

    let normalizeVec3 (v: Vec3) =
        divideVec3 v (nVec3 (Math.Sqrt(v.X ** 2. + v.Y ** 2. + v.Z ** 2.)))

    type Plane = { Centroid: Vec3; Normal: Vec3 }

    let defaultPlane =
        { Centroid = zeroVec3
          Normal = zeroVec3 }

    let distPlane (p: Plane) =
        dotOneVec3 (multiplyVec3 p.Centroid p.Normal)

    let projectPlane (p: Plane) (v: Vec3) =
        let num = dotVec3 p.Normal v

        let vec =
            multiplyVec3 p.Normal (nVec3 (num + (distPlane p)))

        subtractVec3 v vec

    let thetaRadians (p: Plane) : Vec2 =
        let projStart = projectPlane p zeroVec3
        let projX = projectPlane p xVec3
        let projY = projectPlane p yVec3

        toVec2
            (Math.Atan((projX.Z - projStart.Z) / (projX.X - projStart.X)))
            (Math.Atan((projY.Z - projStart.Z) / (projY.Y - projStart.Y)))

    let thetaDegrees (p: Plane) : Vec2 =
        let radians = thetaRadians p
        toVec2 (radians.X * (180. / Math.PI)) (radians.Y * (180. / Math.PI))

    type Covariance =
        { XX: float
          XY: float
          XZ: float
          YY: float
          YZ: float
          ZZ: float }

    let defaultCovariance =
        { XX = 0.
          XY = 0.
          XZ = 0.
          YY = 0.
          YZ = 0.
          ZZ = 0. }

    let addCovariance (c: Covariance) (v: Vec3) =
        { XX = c.XX + (v.X * v.X)
          XY = c.XY + (v.X * v.Y)
          XZ = c.XZ + (v.X * v.Z)
          YY = c.YY + (v.Y * v.Y)
          YZ = c.YZ + (v.Y * v.Z)
          ZZ = c.ZZ + (v.Z * v.Z) }

    let averageCovariance (c: Covariance) (n: float) =
        { XX = c.XX / n
          XY = c.XY / n
          XZ = c.XZ / n
          YY = c.YY / n
          YZ = c.YZ / n
          ZZ = c.ZZ / n }

    let detX (c: Covariance) = c.YY * c.ZZ - c.YZ * c.YZ

    let detY (c: Covariance) = c.XX * c.ZZ - c.XZ * c.XZ

    let detZ (c: Covariance) = c.XX * c.YY - c.XY * c.XY

    let weightedDir (c: Covariance) =
        let mutable out = zeroVec3

        let detX = detX c

        let axis_dir: Vec3 =
            { X = detX
              Y = c.XZ * c.YZ - c.XY * c.ZZ
              Z = c.XY * c.YZ - c.XZ * c.YY }

        let mutable weight = detX ** 2.

        if dotVec3 out axis_dir < 0.0 then
            weight <- -weight

        out <- addVec3 out (multiplyVec3 axis_dir (nVec3 weight))

        let detY = detY c

        let axis_dir: Vec3 =
            { X = c.XZ * c.YZ - c.XY * c.ZZ
              Y = detY
              Z = c.XY * c.XZ - c.YZ * c.XX }

        let mutable weight = detY ** 2.

        if dotVec3 out axis_dir < 0.0 then
            weight <- -weight

        out <- addVec3 out (multiplyVec3 axis_dir (nVec3 weight))

        let detZ = detZ c

        let axis_dir: Vec3 =
            { X = c.XY * c.YZ - c.XZ * c.YY
              Y = c.XY * c.XZ - c.YZ * c.XX
              Z = detZ }

        let mutable weight = detX ** 2.

        if dotVec3 out axis_dir < 0. then
            weight <- -weight

        out <- addVec3 out (multiplyVec3 axis_dir (nVec3 weight))

        out

    let dataPlaneFit (data: Position []) =
        let vecs = data |> Array.map (fun x -> posToVec3 x)
        let n = float vecs.Length

        if n < 3. then
            (0., 0.)
        else
            let mutable sum = zeroVec3

            for v in vecs do
                sum <- addVec3 sum v

            let centroid = multiplyVec3 sum (nVec3 (1. / n))

            let mutable covar = defaultCovariance

            for v in vecs do
                let r = subtractVec3 v centroid
                covar <- addCovariance covar r

            covar <- averageCovariance covar n

            let p: Plane =
                { Centroid = centroid
                  Normal = normalizeVec3 (weightedDir covar) }

            let theta = thetaDegrees p
            (theta.X, theta.Y)

module Report =
    type State =
        | Pass = 0
        | Fail = 1
        | Null = 2
        | Misaligned = 3
        | Other = 4

    let toState (num: int) = enum<State> num

    type Entry =
        { ImageNumber: int
          XCopy: int
          YCopy: int
          Name: string
          mutable State: State
          RR: int
          RC: int
          R: int
          C: int
          X: float
          Y: float
          Score: float }

    let toEntry (data: string) =
        let columns = data.Split('\t')
        let ImageNumber = int columns.[0]
        let XCopy = int columns.[1]
        let YCopy = int columns.[2]
        let Name = string columns.[3]

        let mutable State =
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
        let Score = float columns.[11]

        { ImageNumber = ImageNumber
          XCopy = XCopy
          YCopy = YCopy
          Name = Name
          State = State
          RR = RR
          RC = RC
          R = R
          C = C
          X = X
          Y = Y
          Score = Score }

    type Bucket =
        | Buffer = 0
        | Required = 1
        | NeedOne = 2

    let toBucket (num: int) = enum<Bucket> num

    type Criteria =
        { Name: string
          mutable Bucket: Bucket
          mutable Requirements: State []
          mutable Children: List<Criteria>
          mutable FamilyName: string
          mutable IsChild: bool
          mutable IsParent: bool }

    let toCriteria (name: string) =
        { Name = name
          Bucket = Bucket.Buffer
          Requirements = [| State.Pass |]
          Children = []
          FamilyName = ""
          IsChild = false
          IsParent = false }

    let verify (path: string) =
        let data = File.ReadAllLines path

        if data.Length < 2 then
            0 //Insufficient Data/Empty File
        else
            let firstLineCols = data.[0].Split('\t')

            if firstLineCols.Length < 12 then
                3 // Not enough cols
            else
                let state =
                    match firstLineCols.[4] with
                    | "Pass" -> State.Pass
                    | "Fail" -> State.Fail
                    | "Null" -> State.Null
                    | "Misaligned" -> State.Misaligned
                    | _ -> State.Other

                if state = State.Other then 3 else 1

    let reader (path: string) =
        let data = File.ReadAllLines path

        data
        |> Array.filter (fun x -> x <> "")
        |> Array.map toEntry

    let data (path: string) = reader path

    let getNumImages (data: Entry []) =
        data
        |> Array.map (fun x -> x.ImageNumber)
        |> Array.toSeq
        |> Seq.distinct
        |> Seq.length

    let getNumX (data: Entry []) =
        data
        |> Array.map (fun x -> x.XCopy)
        |> Array.toSeq
        |> Seq.distinct
        |> Seq.length

    let getNumY (data: Entry []) =
        data
        |> Array.map (fun x -> x.YCopy)
        |> Array.toSeq
        |> Seq.distinct
        |> Seq.length

    let getFeatures (data: Entry []) =
        data
        |> Array.map (fun x -> x.Name)
        |> Array.toSeq
        |> Seq.distinct
        |> Seq.toArray
        |> Array.map toCriteria

    let getData (data: Entry [], name: string) =
        data
        |> Array.filter (fun x -> x.Name = name)
        |> Array.map (fun x -> x.Score)

    let rescoreFeature (data: Entry [], name: string, min: float, max: float) =
        for d in data do
            if d.Name = name then
                if d.Score >= min && d.Score <= max then
                    d.State <- State.Pass
                else
                    d.State <- State.Fail

    let getImage (data: Entry [], num: int) =
        data
        |> Array.filter (fun x -> x.ImageNumber = num)

    let getRegions (data: Entry[]) =
        data
        |> Array.map (fun x -> x.RR, x.RC, x.R, x.C)
        |> Array.map (fun x -> x.ToString())
        |> Array.toSeq
        |> Seq.distinct
        |> Seq.toArray

    let getRegion (data: Entry [], region: string) =
        data
        |> Array.filter(fun x -> (x.RR, x.RC, x.R, x.C).ToString() = region)

    let getCell (data: Entry [], row: int, col: int) =
        data
        |> Array.filter (fun x -> x.XCopy = row && x.YCopy = col)

    let removeBuffers (data: Entry [], names: string []) =
        let nameList = names |> Array.toList

        data
        |> Array.filter (fun x -> not (List.contains x.Name nameList))
