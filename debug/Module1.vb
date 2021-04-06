Imports System.IO

Module Module1

    Sub Main()

        Dim dir As DirectoryInfo = New FileInfo(Reflection.Assembly.GetExecutingAssembly.Location).Directory

        'Console.WriteLine(Environment.CommandLine)

        Using SW As New StreamWriter(
            Path.Combine(
                dir.FullName,
                String.Format(
                    "log{0}{1}{2}.txt",
                    Now.Year.ToString,
                    Right("00" & Now.Month.ToString, 2),
                    Right("00" & Now.Day.ToString, 2)
                )
            ), True
        )
            Dim str As String = Split(Environment.CommandLine, Environment.GetCommandLineArgs.First)(1)
            While Left(str, 1) = Chr(32) Or Left(str, 1) = Chr(34)
                str = str.Substring(1, Len(str) - 1)
            End While

            SW.WriteLine(
                String.Format(
                    "{0}:{1}:{2}:{3}> {4}",
                    Right("00" & Now.Hour.ToString, 2),
                    Right("00" & Now.Minute.ToString, 2),
                    Right("00" & Now.Second.ToString, 2),
                    Right("000" & Now.Millisecond.ToString, 3),
                    str
                )
            )

        End Using

    End Sub

End Module
