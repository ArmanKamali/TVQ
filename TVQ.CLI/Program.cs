﻿using Genometric.TVQ.CLI;
using System.Collections.Generic;

namespace TVQ.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var toolShed = new ToolShed();
            var tools = toolShed.GetToolsList();
            tools.Wait();

            var extTools = new List<ExtTool>();
            foreach (var tool in tools.Result)
                extTools.Add(new ExtTool(tool));

            var report = toolShed.DownloadArchives(tools.Result, args[0]);
            report.Wait();

            string toolJSerializePath = @"C:\Users\Vahid\Desktop\test\";
            toolShed.ExtractCitation(args[0], toolJSerializePath, extTools).Wait();

            var scopusClient = new Scopus("...");
            scopusClient.GetCitations(toolJSerializePath, @"C:\Users\Vahid\Desktop\SumCitations.txt");
        }
    }
}
