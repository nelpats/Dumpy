using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Nop
    {
        static int count = 0;
        public static void RemoveInstructions(ModuleDefMD module)
        {
            foreach (TypeDef type in module.Types)
                foreach (MethodDef method in type.Methods)
                {
                    if (method.HasBody)
                        if (method.Body.HasInstructions)
                        {
                            IList<Instruction> instr = method.Body.Instructions;
                            for (int i = 1; i < instr.Count; i++)
                            {
                                if (instr[i].OpCode == OpCodes.Nop)
                                {
                                    instr.Remove(instr[i]);
                                    count++;
                                }
                                 
                            }
                       }
                }

                Logger.Log($"Removed {count} useless NOP instructions");
        }
    }
