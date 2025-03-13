open System

let maxchislo n =
    let rec findMax maxSoFar num =
        if num = 0 then maxSoFar
        else findMax (max maxSoFar (num % 10)) (num / 10)
    findMax 0 n

let poiskmaxchisla numbers = List.map maxchislo numbers

let generateRandomNumbers count =
    let rnd = Random()
    List.init count (fun _ -> rnd.Next(1, 10000))

let rec readchisla acc =
    printf "Введите число (или пустую строку для завершения): "
    match Console.ReadLine() with
    | "" -> List.rev acc
    | input ->
        match Int32.TryParse(input) with
        | true, n when n > 0 -> readchisla (n :: acc)
        | _ ->
            printfn "Некорректный ввод. Попробуйте снова."
            readchisla acc


printf "Выберите способ ввода (1 - случайные числа, 2 - ввод вручную): "
match Console.ReadLine() with
| "1" ->
    let numbers = generateRandomNumbers 5
    printfn "Сгенерированные числа: %A" numbers
    printfn "Максимальные цифры: %A" (poiskmaxchisla numbers)
| "2" ->
    let numbers = readchisla []
    printfn "Введенные числа: %A" numbers
    printfn "Максимальные цифры: %A" (poiskmaxchisla numbers)
| _ ->
    printfn "Некорректный выбор."