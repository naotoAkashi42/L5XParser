using L5XParser.Model.ProgramElement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace L5XParser.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(new string[] { "<![CDATA[GEQ(SrcIndex,SrcLength)[OTL(DN) ,JMP(lblEND) ];]]>","GEQ", "OTL", "JMP" })]
        [DataRow(new string[] { "<![CDATA[CLR(WorkDest)CLR(ScanCount)OTU(SkipUnderscore);]]>", "CLR", "CLR", "OTU" })]
        [DataRow(new string[] { "<![CDATA[XIO(ScanNext)EQU(SrcASCVal,35)EQU(ScanCount,2)EQU(WorkDest,16#16)[CLR(WorkDest) ,CLR(ScanCount) ,OTL(SkipUnderscore) ,OTL(SkipChar) OTL(ScanNext) ];]]>", "XIO", "EQU", "EQU", "EQU", "CLR", "CLR", "OTL", "OTL", "OTL" })]
        public void ExtraInstructionTest(string[] input)
        {
            var text = input[0];
            var ans = input.ToList().Skip(1).ToList();

            var rung = new Rung("0", "dummy comment", text);
           
            var insts = rung.GetUsingInstructions();

            foreach(var item in insts.Select((inst, index) => new {inst, index }))
            {
                Assert.IsTrue(item.inst.Equals(ans[item.index]));
            }
        }
    }
}