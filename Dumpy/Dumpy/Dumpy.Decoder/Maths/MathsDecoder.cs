using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths
{ 
    public class MathsDecoder
    {
        public static void Decode(ModuleDefMD module)
        {          
            Log10.RemovedMutations(module);
            Log.RemovedMutations(module);
            //Cos.RemovedMutations(module);
            Truncate.RemovedMutations(module);
            Floor.RemovedMutations(module);
            Round.RemoveMutations(module);  
            DoubleParse.RemoveMutations(module);
            Length.RemoveMutations(module);
            EmpyTypes.RemoveMutations(module);
            Abs.RemoveMutations(module);
            SizeOf.RemoveMutations(module);
            Add.RemoveMutations(module);
            Sub.RemoveMutations(module);
            Mul.RemoveMutations(module);
            Div.RemoveMutations(module);
            ToInt32.RemoveMutations(module);
            Xor.RemoveMutations(module);
            Ldci4ToConvi4Handler.Fix(module);
        }
    }
}
