using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ToInt32
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
                            if (instr[i].OpCode == OpCodes.Call && instr[i].Operand.ToString().Contains("ToInt32"))
                            {

                                if (instr[i - 1].OpCode == OpCodes.Ldc_R4 || instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    int result = Convert.ToInt32(instr[i - 1].Operand);
                                    instr[i - 1].OpCode = OpCodes.Ldc_I4;
                                    instr[i - 1].Operand = result;
                                    instr[i].OpCode = OpCodes.Nop;
                                    count++;
                                }
                                else
                                {
                                    if (instr[i - 2].OpCode == OpCodes.Ldc_R4 || instr[i - 2].OpCode == OpCodes.Ldc_R8)
                                    {
                                        int result = Convert.ToInt32((instr[i - 2].Operand));
                                        instr[i - 2].OpCode = OpCodes.Ldc_I4;
                                        instr[i - 2].Operand = result;
                                        instr[i].OpCode = OpCodes.Nop;
                                        count++;
                                    }
                                }
                                    

                            }
                         
                        }
                    }
            }
        Logger.Log($"Removed {count} ToInt32 Mutations");

    }
        

}


