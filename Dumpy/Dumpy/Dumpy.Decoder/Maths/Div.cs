using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths
{
    public class Div
    {
        static int count = 0;
        public static void RemoveMutations(ModuleDefMD module)
        {
            foreach (TypeDef types in module.Types)
                foreach (MethodDef method in types.Methods)
                {
                    if (method.HasBody)
                        if (method.Body.HasInstructions)
                        {
                            IList<Instruction> instr = method.Body.Instructions;
                            for (int i = 0; i < instr.Count; i++)
                            {
                                if (instr[i].OpCode == OpCodes.Div && instr[i - 1].IsLdcI4() && instr[i - 2].IsLdcI4())
                                {
                                    int result = instr[i - 1].GetLdcI4Value() /  instr[i - 2].GetLdcI4Value();
                                    instr[i].OpCode = OpCodes.Ldc_I4;
                                    instr[i].Operand = result;
                                    instr[i - 1].OpCode = OpCodes.Nop;
                                    instr[i - 2].OpCode = OpCodes.Nop;
                                    count++;
                                }
                            }
                        }

                }
            Logger.Log($"Removed {count} Div mutations");

        }
    }
}
