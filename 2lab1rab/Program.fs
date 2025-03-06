open System

// Функция для нахождения максимальной цифры в числе
let maxchislo (n: int) =
    n.ToString()
    |> Seq.map (fun c -> int c - int '0')
    |> Seq.max

// Функция для обработки списка чисел
let processList (numbers: int list) : int list =
    numbers |> List.map maxchislo

// Функция для безопасного ввода списка натуральных чисел
let readNumbers () =
    printfn "Введите натуральные числа через пробел:"
    let input = Console.ReadLine()

    try
        input.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
        |> List.ofSeq
        |> List.map (fun x -> 
            if x.Contains('.') || x.Contains(',') then 
                raise (System.FormatException("Число не должно быть дробным!"))
            
            let num = int x
            if num <= 0 then raise (System.FormatException("Число должно быть натуральным!"))
            num
        )
    with
    | :? System.FormatException as e -> 
        printfn "Ошибка: %s" e.Message
        []  // Возвращаем пустой список вместо повторного ввода

// Основная программа
[<EntryPoint>]
let main argv =
    let numbers = readNumbers()
    
    if numbers.IsEmpty then
        printfn "Программа завершена из-за ошибки ввода."
        1  // Код ошибки
    else
        let result = processList numbers
        printfn "Максимальные цифры: %A" result
        0  // Код успешного завершения