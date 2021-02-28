namespace XferHelper

open MathNet.Numerics.Statistics

module Stats =
    let median (data:float[]) =
        Statistics.Median(data)

    let stdDev (data:float[]) =
        Statistics.PopulationStandardDeviation(data)

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