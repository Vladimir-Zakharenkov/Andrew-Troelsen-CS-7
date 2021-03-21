﻿// ГЛАВА 3

// Главные конструкции программирования на С#: часть I

// В настоящей главе начинается формальное изучение языка программирования
// C# за счет представления набора отдельных тем, которые необходимо знать для
// освоения инфраструктуры .NET Framework. В первую очередь мы разберемся, каким
// образом строить объект приложения, и выясним структуру точки входа исполняемой
// программы — метода Main (). Затем мы исследуем фундаментальные типы данных C#
// (и их эквиваленты в пространстве имен System), в том числе классы System.String и
// System.Text.StringBuilder.

// После ознакомления с деталями фундаментальных типов данных .NET мы рассмотрим
// несколько приемов преобразования типов данных, включая сужающие и расширяющие
// операции, а также использование ключевых слов checked и unchecked.

// Кроме того, в главе будет описана роль ключевого слова var языка С#, которое позволяет
// неявно определять локальную переменную. Как будет показано далее в книге,
// неявная типизация чрезвычайно удобна (а порой и обязательна) при работе с набором
// технологий LINQ. Глава завершается кратким обзором ключевых слов и операций С#, которые
// дают возможность управлять последовательностью выполняемых в приложении
// действий с применением разнообразных конструкций циклов и принятия решений.

// Структура простой программы C#

// Язык C# требует, чтобы вся логика программы содержалась внутри определения типа
// (вспомните из главы 1, что тип — это общий термин, относящийся к любому члену из
// множества {класс, интерфейс, структура, перечисление, делегат}). В отличие от многих
// других языков создавать глобальные функции или глобальные элементы данных в C#
// невозможно. Взамен все данные-члены и все методы должны находиться внутри определения
// типа. Первым делом создадим новый проект консольного приложения по имени
// SimpleCSharpApp. Код в первоначальном файле Program, cs не особо примечателен:

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace SimpleCSharpApp
// {
//    class Program
//    {
//        static void Main(string[] args)
//        {

//        }
//    }
// }

// Теперь модифицируем метод Main() класса Program следующим образом:

// class Program
// {
//    static int Main(string[] args)
//    {
//        //Display a simple message to the user.
//        //Вывести пользователю простое сообщение.
//        Console.WriteLine("***** My First C# App *****");
//        Console.WriteLine("Hello World!");
//        Console.WriteLine();

//        Wait for Enter key to be pressed before shutting down.
//        Ожидать нажатия клавиши <Enter>, прежде чем завершить работу.
//        Console.ReadLine();

//        // Return an arbitrary error code.
//        return -1;
//    }
// }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCSharpApp
{
    class Program
    {
        static int Main(string[] args)
        {
            // Display a simple message to the user.
            Console.WriteLine("***** My First C# App *****");
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            // Process any incoming args.
            //Обработать любые входные аргументы.
            //for (int i = 0; i < args.Length; i++)
            //    Console.WriteLine("Arg: {0}", args[i]);

            // Process any incoming args using foreach.
            //Обработать любые входные аргументы, используя foreach.
            //foreach (string arg in args)
            //    Console.WriteLine("Arg: {0}", arg);

            // Get arguments using System.Environment.
            //Получить аргументы с использованием System.Environment.
            //string[] theArgs = Environment.GetCommandLineArgs();
            //foreach (string arg in theArgs)
            //    Console.WriteLine("Arg: {0}", arg);

            // Helper method within the Program class.
            //Вспомогательный метод внутри класса Program.
            ShowEnvironmentDetails();

            //Wait for Enter key to be pressed before shutting down.
            //Ожидать нажатия клавиши<Enter>, прежде чем завершить работу.
            Console.ReadLine();

            //Return an arbitrary error code.
            //Возвратить произвольный код ошибки.
            return -1;
        }

        private static void ShowEnvironmentDetails()
        {
            //Print out the drives on this machine, and other interesting details.
            //Вывести информацию о дисковых устройствах данной машины и другие интересные детали,
            foreach (string drive in Environment.GetLogicalDrives())
                Console.WriteLine("Drive: {0}", drive);

            Console.WriteLine("OS: {0}", Environment.OSVersion);

            Console.WriteLine("Number of processors: {0}",
                Environment.ProcessorCount);

            Console.WriteLine(".NET Version: {0}",
                Environment.Version);
        }
    }
}

// На заметку!
// Язык программирования C# чувствителен к регистру Следовательно, Main — не то
// же самое, что main, a Readline — не то же самое, что ReadLine. Запомните, что все ключевые
// слова C# вводятся в нижнем регистре (например, public, lock, class, dynamic), в
// то время как названия пространств имен, типов и членов (по соглашению) начинаются с заглавной
// буквы и имеют заглавные буквы в любых содержащихся внутри словах (скажем, Console.
// WnteLine, System. Windows .MessageBox и System. Data . SqlClient). Как правило,
// каждый раз, когда вы получаете от компилятора сообщение об ошибке, касающееся неопределенных
// символов, то в первую очередь должны проверить правильность написания и регистр.

// В предыдущем коде имеется определение типа класса, который поддерживает единственный
// метод по имени Main(). По умолчанию среда Visual Studio назначает классу,
// определяющему метод Main(), имя Program; однако при желании его можно изменить.
// Каждое исполняемое приложение C# (консольная программа, настольная программа
// Windows или Windows-служба) должно содержать класс, определяющий метод Main(),
// который используется для обозначения точки входа в приложение.

// Выражаясь формально, класс, в котором определен метод Main(), называется объектом
// приложения. Хотя в одном исполняемом приложении допускается иметь несколько
// объектов приложений (что может быть удобно при модульном тестировании), вы должны
// проинформировать компилятор о том, какой из методов Main() должен применяться
// в качестве точки входа. Это делается с помощью опции /main компилятора командной
// строки или посредством раскрывающегося списка Startup Object (Объект запуска)
// на вкладке Application (Приложение) окна свойств проекта Visual Studio (см. главу 2).

// Обратите внимание, что сигнатура метода Main () снабжена ключевым словом
// static, которое подробно объясняется в главе 5. Пока достаточно знать, что статические
// члены имеют область видимости уровня класса (а не уровня объекта) и потому могут
// вызываться без предварительного создания нового экземпляра класса.

// Помимо наличия ключевого слова static метод Main() принимает единственный
// параметр, который представляет собой массив строк (string[] args). Несмотря на то
// что в текущий момент данный массив никак не обрабатывается, параметр args может
// содержать любое количество входных аргументов командной строки (доступ к ним будет
// вскоре описан). Наконец, метод Main() в примере был определен с возвращаемым
// значением void, т.е. перед выходом из области видимости метода мы не устанавливаем
// явным образом возвращаемое значение с использованием ключевого слова return.

// Внутри метода Main() содержится логика класса Program. Здесь мы работаем с
// классом Console, который определен в пространстве имен System. В состав его членов
// входит статический метод WriteLine(), который отправляет текстовую строку и символ
// возврата каретки в стандартный вывод. Кроме того, мы производим вызов метода
// Console.ReadLine(), чтобы окно командной строки, открываемое IDE-средой Visual
// Studio, оставалось видимым на протяжении сеанса отладки до тех пор, пока не будет
// нажата клавиша <Enter>. (Если вы не добавите такую строку кода, то приложение завершится
// прямо во время сеанса отладки, и вы не сможете просмотреть результирующий
// вывод!) Класс System.Console более подробно рассматривается далее в главе.

// Вариации метода Main()

// По умолчанию Visual Studio будет генерировать метод Main() с возвращаемым значением
// void и одним входным параметром в виде массива строк. Тем не менее, это не
// единственно возможная форма метода Main(). Точку входа в приложение разрешено
// создавать с использованием любой из приведенных ниже сигнатур (предполагая, что
// они содержатся внутри определения класса или структуры С#):

// //Возвращаемый тип int, массив строк в качестве параметра,
// static int Main(string[] args)
// {
//    //Перед выходом должен возвращать значение!
//    return 0;
// }

// //Нет возвращаемого типа, нет параметров,
// static void Main()
// {
// }

// //Возвращаемый тип int, нет параметров,
// static int Main()
// {
//    // Перед выходом должен возвращать значение!
//    return 0;
// }

// На заметку!
// Метод Main() может быть также определен как открытый в противоположность закрытому,
// что подразумевается, если не указан конкретный модификатор доступа. Среда Visual
// Studio определяет метод Main() как неявно закрытый.

// Очевидно, что выбор способа создания метода Main() зависит от ответов на два
// вопроса. Первый вопрос: нужно ли возвращать значение системе, когда метод Main()
// заканчивается и работа программы завершается? Если да, тогда необходимо возвращать
// тип данных int, а не void. Второй вопрос: требуется ли обрабатывать любые
// предоставляемые пользователем параметры командной строки? Если да, то они будут
// сохранены в массиве строк. Ниже мы обсудим все варианты более подробно.

// Асинхронные методы Main О (нововведение)

// С выходом версии C# 7.1 метод Main() может быть асинхронным. Асинхронное программирование
// рассматривается в главе 19, а пока следует знать, что появились четыре дополнительных сигнатуры:

// static Task Main()
// static Task<int> Main()
// static Task Main(string[])
// static Task<int> Main(string[])

//Они будут раскрыты в главе 19.

// Указание кода ошибки приложения

// Хотя в подавляющем большинстве случаев методы Main() будут иметь void в качестве
// возвращаемого значения, возможность возвращения int из Main() сохраняет
// согласованность C# с другими языками, основанными на С. По соглашению возврат
// значения 0 указывает на то, что программа завершилась успешно, тогда как любое
// другое значение (вроде -1) представляет условие ошибки (имейте в виду, что значение
// 0 автоматически возвращается даже в случае, если метод Main() прототипирован для
// возвращения void).

// В ОС Windows возвращаемое приложением значение сохраняется в переменной среды
// по имени %ERRORLEVEL%. Если создается приложение, которое программно запускает
// другой исполняемый файл (тема, рассматриваемая в главе 18), тогда получить значение
// %ERRORLEVEL% можно с применением статического свойства System.Diagnostics.Process.ExitCode.

// Поскольку возвращаемое значение передается системе в момент завершения работы
// приложения, вполне очевидно, что получить и отобразить финальный код ошибки во
// время выполнения приложения невозможно. Однако мы покажем, как просмотреть код
// ошибки по завершении программы, изменив метод Main() следующим образом:

// Обратите внимание, что теперь возвращается int, а не void,
// static int Main(string[] args)
// {
//    //Вывести сообщение и ожидать нажатия клавиши <Enter>.
//    Console.WriteLine("***** My First C# App *****");
//    Console.WriteLine("Hello World!");
//    Console.WriteLine();
//    Console.ReadLine();
//    //Возвратить произвольный код ошибки,
//    return -1;
// }

// Теперь давайте захватим возвращаемое значение метода Main() с помощью пакетного
// файла. Используя проводник Windows, перейдите в папку, где находится файл
// решения (например, С:\SimpleCSharpApp\). Добавьте в нее новый текстовый файл (по
// имени SimpleCSharpApp.bat), содержащий приведенные далее инструкции (если раньше
// вам не приходилось создавать файлы .bat, то можете не беспокоиться о внутренних
// нюансах — это всего лишь тест):

// @echo off
// rem Пакетный файл для приложения SimpleCSharpApp.exe,
// rem в котором захватывается возвращаемое им значение.
// .\SimpleCSharpApp\bin\debug\SimpleCSharpApp
// @if "%ERRORLEVELV == "0" goto success
// :fail
// rem Приложение потерпело неудачу,
// echo This application has failed!
// echo return value = %ERRORLEVEL%
// goto end
// :success
// rem Приложение успешно завершено,
// echo This application has succeeded!
// echo return value = %ERRORLEVEL%
// goto end
// :end
// rem Работа сделана,
// echo All Done.

// В подавляющем большинстве приложений C# (если только не во всех) в качестве возвращаемого
// значения метода Main() будет применяться void, что подразумевает неявное
// возвращение нулевого кода ошибки. Поэтому все методы Main() в книге (кроме
// текущего примера) на самом деле будут возвращать void (и оставшиеся проекты определенно
// не нуждаются в использовании пакетных файлов для перехвата кодов возврата).

// Обработка аргументов командной строки

// Теперь, когда вы лучше понимаете, что собой представляет возвращаемое значение
// метода Main(), давайте посмотрим на входной массив строковых данных. Предположим,
// что нам необходимо модифицировать приложение для обработки любых возможных параметров
// командной строки. Один из способов предусматривает применение цикла for
// языка С#. (Все итерационные конструкции языка C# более подробно рассматриваются
// в конце главы.)

// static int Main(string[] args)
// {
//      ...
//      //Обработать любые входные аргументы.
//      for (int i = 0; i < args.Length; i++)
//          Console.WriteLine( ”Arg: {0}", args[i]);
//          Console.ReadLine();
//          return -1;
// }

// Здесь с использованием свойства Length класса System.Array производится проверка,
// есть ли элементы в массиве строк. Как будет показано в главе 4, все массивы C#
// фактически являются псевдонимом класса System.Array и потому разделяют общий
// набор членов. По мере прохода в цикле по элементам массива их значения выводятся
// на консоль. Предоставить аргументы в командной строке в равной степени просто:

// С:\SimpleCSharpApp\bin\Debug>SimpleCSharpApp.ехе /argl - arg2
// *****My First C# Арр *****
// Hello World!
// Arg: / argl
// Arg: -arg2

// В качестве альтернативы стандартному циклу for для реализации прохода по входному
// массиву данных string можно также применять ключевое слово foreach. Вот
// пример использования foreach (особенности конструкций циклов обсуждаются далее в главе):

// //Обратите внимание, что в случае применения foreach
// //отпадает необходимость в проверке размера массива.
// static int Main(string[] args)
// {
//      ...
//      //Обработать любые входные аргументы, используя foreach.
//      foreach (string arg in args)
//          Console.WriteLine("Arg: {0}", arg);
//      Console.ReadLine();
//      return -1;
//  }

// Наконец, доступ к аргументам командной строки можно также получать с помощью
// статического метода GetCommandLineArgs() типа System.Environment. Данный метод
// возвращает массив элементов string. Первый элемент содержит имя самого приложения,
// а остальные — индивидуальные аргументы командной строки. Обратите внимание,
// что при таком подходе больше не обязательно определять метод Main () как принимающий
// массив string во входном параметре, хотя никакого вреда от этого не будет.

// static int Main(string[] args)
// {
//      ...
//      //Получить аргументы с использованием System.Environment.
//      string[] theArgs = Environment.GetCommandLineArgs();
//      foreach (string arg in theArgs)
//          Console.WriteLine("Arg: {0}", arg);

//      Console.ReadLine();
//      return -1;

// Разумеется, именно на вас возлагается решение о том, на какие аргументы командной
// строки должна реагировать программа (если они вообще будут предусмотрены),
// и как они должны быть сформатированы (например, с префиксом - или /). В показанном
// выше коде мы просто передаем последовательность аргументов, которые выводятся
// прямо в окно командной строки. Однако предположим, что создается новое игровое
// приложение, запрограммированное на обработку параметра вида -godmode. Когда
// пользователь запускает приложение с таким флагом, в отношении него можно было бы
// предпринять соответствующие действия.

// Указание аргументов командной строки в Visual Studio

// В реальности конечный пользователь при запуске программы имеет возможность
// предоставлять аргументы командной строки. Тем не менее, указывать допустимые
// флаги командной строки также может требоваться во время разработки в целях тестирования
// программы. Чтобы сделать это в Visual Studio, дважды щелкните на значке
// Properties(Свойства) в проводнике решений. Затем в открывшемся окне свойств перейдите
// на вкладку Debug (Отладка) и в текстовом поле Command line arguments (Аргументы
// командной строки) введите желаемые аргументы (рис. 3.1).

// Указанные аргументы командной строки будут автоматически передаваться методу
// Main() во время отладки или запуска приложения внутри IDE-среды Visual Studio.

// Интересное отступление от темы:
// некоторые дополнительные члены класса System.Environment

// Помимо метода GetCommandLineArgs() класс Environment открывает доступ к
// ряду других чрезвычайно полезных методов. В частности, с помощью разнообразных
// статических членов этот класс позволяет получать детальные сведения, касающиеся
// операционной системы, под управлением которой в текущий момент функционирует
// приложение .NET. Чтобы проиллюстрировать полезность класса System.Environment,
// изменим код метода Main() , добавив вызов вспомогательного метода по имени
// ShowEnvironmentDetails():

// static int Main(string[] args)
// {
//    ...
//    //Вспомогательный метод внутри класса Program.
//    ShowEnvironmentDetails();
//    Console.ReadLine();
//    return -1;
// }

// Теперь реализуем метод ShowEnvironmentDetails () внутри класса Program для обращения
// в нем к разным членам типа Environment:

// static void ShowEnvironmentDetails()
// {
//    //Вывести информацию о дисковых устройствах данной машины и другие интересные детали.
//    foreach (string drive in Environment.GetLogicalDrives())
//        Console.WriteLine("Drive: {0}", drive); //Логические устройства

//    Console.WriteLine("OS: {0}", Environment.OSVersion); // Версия операционной системы

//    Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount); //Количество процессоров

//    Console.WriteLine(".NET Version: {0}", Environment.Version); //Версия платформы .NET
//  {

// Ниже показан возможный вывод, полученный в результате тестового запуска данного
// метода.Конечно, если на вкладке Debug в Visual Studio не были указаны аргументы
// командной строки, то они и не отобразятся в окне консоли.

// *****My First C# Арр *****
// Hello World!
// Arg: -godmode
// Arg: -argl
// Arg: / arg2
// Drive: C:\
// Drive: D:\
// OS: Microsoft Windows NT 6.2.9200.0
// Number of processors: 8
// .NET Version: 4.0.30319.42000

// В типе Environment определены и другие члены кроме тех, что задействованы в предыдущем
// примере. В табл. 3.1 описаны некоторые интересные дополнительные свойства;
// полные сведения о них можно найти в документации .NET Framework 4.7 SDK.

// Таблица 3.1.Избранные свойства типа System.Environment

// Свойство                 Описание
// ExitCode                 Получает или устанавливает код возврата для приложения
// Is64BitOperatingSystem   Возвращает булевское значение, которое представляет признак
//                          наличия на текущей машине 64-разрядной операционной системы
//MachineName               Возвращает имя текущей машины
//NewLine                   Возвращает символ новой строки для текущей среды
//SystemDirectory           Возвращает полный путь к каталогу системы
//UserName                  Возвращает имя пользователя, запустившего данное приложение
//Version                   Возвращает объект Version, который представляет версию платформы .NET

