using System.Diagnostics;

namespace Logers
{
    public class Loger
    {
        public static int Count { get; set; } = 0;

        public static List<StackTrace> stackOriginTraces = new List<StackTrace>();
        public static List<StackFrame> stackExceptionTraces = new List<StackFrame>();
        public static List<Type> typeLogers = new List<Type>();
        public static List<string?> texts = new List<string?>();
        public static List<DateTime> times = new List<DateTime>();
        public static List<string?> helpLinks = new List<string?>();


        public static void addLoger(string? _text, DateTime _time, Type type, StackTrace stackTrace, string? helpLink = null)
        {
            Count++;
            typeLogers.Add(type);
            texts.Add(_text);
            times.Add(_time);
            stackExceptionTraces.Add(stackTrace.GetFrame(0));
            stackOriginTraces.Add(stackTrace);
            helpLinks.Add(helpLink is not null ? helpLink : "NONE_LINK");
        }
        private static string showParentsLoger(in Type type)
        {
            string typesText = "";
            Type? parent = type.BaseType;
            while (parent != null)
            {
                typesText = typesText.Insert(0, $"{parent.Name}.");
                parent = parent.BaseType;
            }
            typesText += type.Name;

            return typesText;
        }
        private static string showFullFrame(in int index)
        {
            if (index < 0 || index >= stackOriginTraces.Count)
                return string.Empty;

            string frameText = "";
            for (int i = 0; i < stackOriginTraces[index].FrameCount; i++)
            {
                frameText = frameText.Insert(0, $"{stackOriginTraces[index].GetFrame(i)?.GetMethod()?.Name}.");
            }
            return frameText;

        }
        private static string showFullLineMethod(in int index)
        {
            if (index < 0 || index >= stackOriginTraces.Count)
                return string.Empty;


            string methodText = "";
            for (int i = 0; i < stackOriginTraces[index].FrameCount; i++)
            {
                string addText = $"{stackOriginTraces[index].GetFrame(i)?.GetMethod()?.Name}";
                addText += $"(line: {stackOriginTraces[index].GetFrame(i)?.GetFileLineNumber()}) | ";

                methodText = methodText.Insert(0, addText);
            }
            return methodText;

        }
        public static string showLog(in Type type)
        {
            string showText = "";
            string typesText = showParentsLoger(type);



            for (int i = 0; i < Count; i++)
            {
                if (type.IsAssignableFrom(typeLogers[i]) || typeLogers[i].IsAssignableFrom(type))
                {
                    showText += "Loger\nType: " + typesText + "\nText: " + texts[i] + "\nTime: " + times[i].ToString() + "\n";
                    showText += $"Exception Method: {stackExceptionTraces[i].GetMethod()?.Name}\n" + $"Exception Line: {stackExceptionTraces[i].GetFileLineNumber()}\n";
                    // showText += $"Origin Method: {stackOriginTraces[i].GetMethod()?.Name}\n" + $"Origin Line: {stackOriginTraces[i].GetFileLineNumber()}\n";
                    showText += $"Full Method: {showFullFrame(i)}\n" + $"Full line method: {showFullLineMethod(i)}\n";
                    showText += $"File: {stackExceptionTraces[i].GetFileName()}" + "\n";
                    showText += $"Help Link: {helpLinks[i]}" + "\n\n";

                }
            }

            return showText;
        }
        public static string showLog()
        {
            return showLog(typeof(Loger));
        }

    }
}
