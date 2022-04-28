namespace XferHelper

open MathNet.Numerics.Statistics
open MathNet.Numerics.Distributions
open System.IO
open System

module Stats =
    let mean (data: float []) = Math.Round(Statistics.Mean(data), 3)

    let median (data: float []) = Math.Round(Statistics.Median(data), 3)

    let stdDev (data: float []) = Statistics.StandardDeviation(data)

    let threeSig (data: float []) = Math.Round(stdDev (data) * 3.0, 3)

    /// <returns>Probability density at x = i for the distribution data</returns>
    let normVal (data: float []) (i: float) : float =
        let norm = Normal.WithMeanStdDev(mean (data), stdDev (data))
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

    /// <returns>Array of print RR RC R C strings</returns>
    let prints (data: Position []) =
        data
        |> Array.map (fun x -> x.RR, x.RC, x.R, x.C)
        |> Array.map (fun x -> string x)
    
    /// <returns>Position array from specified RR RC R C string</returns>
    let getPrint (index: string) (data: Position []) =
        let info = index.[1 .. index.Length - 2].Split(',')
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

    /// <summary>Update PASS or FAIL state of position array based on new threshold</summary>
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

    ///<returns>Contrived entropy value from position array</returns>
    let nextMagnitudeEntropy (data: Position []) =
        data
        |> normErrorRange
        |> Statistics.Entropy
        |> fun x -> x ** 10.

    let applyFilter (filter: string []) (data: Position []) =
        data
        |> Array.filter (fun x ->
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
    type Axes =
        | None = 0
        | X = 1
        | Y = 2
        | Z = 3
        | H = 4
        | I = 5
        | ZH = 6

    let verify (path: string) =
        let data = File.ReadAllLines path

        if data.Length < 2 then
            0 //Insufficient Data/Empty File
        else
            let firstLineCols = data.[0].Split('\t')

            if firstLineCols.Length < 2 then
                3 // Not enough cols
            else if firstLineCols.[1] = "NEWSCAN" then
                1
            else
                3

    type Position =
        { Time: System.DateTime
          X: float
          Y: float
          Z: float
          H: float
          I: float }

    let toPosition (csvData: string) =
        let columns = csvData.Split('\t')
        let Time = System.DateTime.Parse(columns.[0])
        let X = float columns.[1]
        let Y = float columns.[2]
        let mutable H = float columns.[3] * 1e3
        if columns.[3] = "NaN" then H <- 0.0
        let mutable Z = 0.0
        let mutable I = 0.0

        if columns.Length > 4 then
            Z <- -1.0 * float columns.[4]

        if columns.Length > 5 then
            I <- float columns.[5]

        { Time = Time
          X = X
          Y = Y
          Z = Z
          H = H
          I = I }

    let getAxisMinMax (data: double []) = (data.Minimum(), data.Maximum())

    let getAxis (data: Position []) (axis: int) (flip: bool) =
        let orientation =
            match flip with
            | true -> -1.0
            | false -> 1.0

        match axis with
        | 1 -> data |> Array.map (fun x -> x.X * orientation)
        | 2 -> data |> Array.map (fun x -> x.Y * orientation)
        | 3 -> data |> Array.map (fun x -> x.Z * orientation)
        | 4 -> data |> Array.map (fun x -> x.H * orientation)
        | 5 -> data |> Array.map (fun x -> x.I * orientation)
        | 6 ->
            data
            |> Array.map (fun x -> (x.Z + (x.H / 1e3)) * orientation)
        | _ -> [| 0.0 |]

    let getAxisSingle (p: Position) (axis: int) (flip: bool) =
        let orientation =
            match flip with
            | true -> -1.0
            | false -> 1.0

        match axis with
        | 1 -> p.X * orientation
        | 2 -> p.Y * orientation
        | 3 -> p.Z * orientation
        | 4 -> p.H * orientation
        | 5 -> p.I * orientation
        | 6 -> p.Z + ((p.H / 1e3)) * orientation
        | _ -> 0.0

    let filterData (data: Position []) (axis: int) (min: float) (max: float) =
        if axis > 0 && (min <> 0.0 || max <> 0.0) then
            match axis with
            | 1 ->
                data
                |> Array.filter (fun x -> x.X >= min && max >= x.X)
            | 2 ->
                data
                |> Array.filter (fun x -> x.Y >= min && max >= x.Y)
            | 3 ->
                data
                |> Array.filter (fun x -> x.Z >= min && max >= x.Z)
            | 5 ->
                data
                |> Array.filter (fun x -> x.I >= min && max >= x.I)
            | _ -> data
        else
            data

    let scatterPolynomial (xData: double []) (yData: double []) =
        MathNet.Numerics.Fit.Polynomial(xData, yData, 3)

    let rSquared (model: double []) (observed: double []) =
        System.Math.Round(MathNet.Numerics.GoodnessOfFit.RSquared(model, observed), 3)

    let linearFit (xData: double []) (yData: double []) =
        MathNet.Numerics.Fit.Line(xData, yData)

    // Everything below here pertains to creating a best fit plane
    // from a point cloud
    // This work is largely based on Emil Ernerfeldt's blog post here:
    // http://www.ilikebigbits.com/2017_09_25_plane_from_points_2.html

    type Vec2 = { X: float; Y: float }

    let toVec2 (x: float) (y: float) = { X = x; Y = y }

    type Vec3 = { X: float; Y: float; Z: float }

    let posToVec3 (p: Position) = { X = p.X; Y = p.Y; Z = p.H }

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

        let vec = multiplyVec3 p.Normal (nVec3 (num + (distPlane p)))

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

    let getPlaneVec (vecs: Vec3[]) =
        let n = float vecs.Length
        if n < 3. then
            let p: Plane =
                { Centroid = zeroVec3
                  Normal = normalizeVec3 (weightedDir defaultCovariance) }
            p
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
            p

    ///<returns>Best fit plane for 3D point cloud position array</returns>
    let getPlane (data: Position []) =
        getPlaneVec (data |> Array.map (fun x -> posToVec3 x))

    let dataPlaneFit (p: Plane) =
        let theta = thetaDegrees p
        (theta.X, theta.Y)
