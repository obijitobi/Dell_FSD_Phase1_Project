using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FSD_Teacher
{
    public class Teacher
    {
        public string TID;
        public string Tname;
        public string TClassNo;
        public string TSection;
    }

    public class FSD_School 
    {
        //Location of the Text File 
        public string path = @"C:\FSD_Project\FSD_Rainbow\FSD_Phase1\TeacherRecord.txt";


        public List<Teacher> TTeach001 = new List<Teacher>();

        public void displaymenu()
        {
            
            Console.WriteLine("=====================================================");
            Console.WriteLine(" Teacher Management: ");
            Console.WriteLine("=====================================================");
            Console.WriteLine(" 1.Add Teacher");
            Console.WriteLine(" 2.Display Teacher");
            Console.WriteLine(" 3.Search a Teacher record ");
            Console.WriteLine(" 4.Update a Teacher record");
            Console.WriteLine(" Please select an Option : ");
            Console.WriteLine("=====================================================");
        }

        public void Addrecord()
        {
            try
            {
                
                Console.WriteLine("TeacherID :");
                string TID1 = Console.ReadLine();
                Console.WriteLine("TeacherName:");
                string Tname1 = Console.ReadLine();
                Console.WriteLine("TeacherClass:");
                string TClassNo1 = Console.ReadLine();
                Console.WriteLine("TeacherSection:");
                string TSection1 = Console.ReadLine();

                this.TTeach001 = new List<Teacher>
                {
                new Teacher { TID = TID1, Tname = Tname1, TClassNo = TClassNo1, TSection = TSection1 }
                };

                StreamWriter sw = new StreamWriter(path, true);
                foreach (Teacher Tech in TTeach001)
                {
                    
                    Console.WriteLine($"\nAdd Teacher : {Tech.TID}:{Tech.Tname}:{Tech.TClassNo}:{Tech.TSection}");
                    sw.WriteLine($"{Tech.TID}:{Tech.Tname}:{Tech.TClassNo}:{Tech.TSection}");
                    Console.WriteLine("\n\nTeacher Record Added");
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                
            }
        }

        public void getAllRecord()
        {
            try
            {
                int count = 0;

              
                StreamReader sr1 = new StreamReader(path);
                string msg = sr1.ReadToEnd();
                Console.Write(msg);
                sr1.Close();

                
                using (var sr2 = new StreamReader(path))
                {
                    while (sr2.ReadLine() != null)
                    {
                        count++;
                    }
                }
                Console.WriteLine("\nCount Teacher Record :" + count);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
            finally
            {
               
            }
        }

        public void getParticularRecord(String Tid)
        {
            try
            {
                int recordcount = 0;

               
                List<string> Filelines = System.IO.File.ReadLines(path).ToList();
                for (int i = 0; i < Filelines.Count; i++)
                {
                    if (Filelines[i].Contains(Tid))
                    {
                        Console.WriteLine("\nDisplay Teacher Record =>>\n\n" + Filelines[i]);
                        recordcount++;
                    }
                }

                if (recordcount == 0)
                {
                    Console.WriteLine("\nDidnot find the Teacher Record");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
            finally
            {
                
            }
        }

        public void updateParticularRecord(String TID, String RecordFeild, String Oldvalue, String Newvalue)
        {
            try
            {
                
                StreamReader sr = new StreamReader(path, true);
                string msg = sr.ReadToEnd();
                sr.Close();

                if (msg.Contains(TID))
                {
                    msg = Regex.Replace(msg, Oldvalue, Newvalue);
                    Console.WriteLine("The Row has been edited successfully: " + TID + "  Feild Updated :" + RecordFeild + "  Old Value :" + Oldvalue + "  Newvalue :" + Newvalue);
                }
                else
                {
                    Console.WriteLine("Didnot found the Teacher Record :" + TID);
                }

              
                StreamWriter fname = new StreamWriter(path);
                fname.Write(msg);
                fname.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
            finally
            {
                Console.WriteLine("\n----------------------------------------------\n");
            }
        }
    }

    class FSD_Rainbow : FSD_School
    {
        public static void Main(string[] args)
        {
            int option;
            String userresponse;

            FSD_School schobj = new FSD_School();

            try
            {
                do
                {
                    schobj.displaymenu();

                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            schobj.Addrecord();
                            break;

                        case 2:
                            schobj.getAllRecord();
                            break;

                        case 3:
                            Console.WriteLine("Enter Teacher ID");
                            String TID1 = Console.ReadLine();
                            schobj.getParticularRecord(TID1);
                            break;

                        case 4:
                            Console.WriteLine("Enter the Teacher ID");
                            String TID = Console.ReadLine();
                            schobj.getParticularRecord(TID);

                            Console.WriteLine("\n What you want to Update  ?");
                            String RecordFeild = Console.ReadLine();
                            Console.WriteLine("\nEnter the the old Value");
                            String Oldvalue = Console.ReadLine();
                            Console.WriteLine("\nEnter the New Value");
                            String Newvalue = Console.ReadLine();

                            schobj.updateParticularRecord(TID, RecordFeild, Oldvalue, Newvalue);
                            break;

                        default:
                            {
                                Console.WriteLine("\nPlease select the correct option");
                                break;
                            }
                    }

                    Console.WriteLine("Do you want to Continue :(yes / no)");
                    userresponse = Console.ReadLine();
                    Console.WriteLine("\n-------------------------------\n");
                    //Console.Clear();

                }
                while (userresponse.Equals("yes", StringComparison.OrdinalIgnoreCase));
            }

            catch (Exception Ex)
            {
                Console.WriteLine("Exception" + Ex);
            }

            Console.ReadKey();
        }
    }
}
