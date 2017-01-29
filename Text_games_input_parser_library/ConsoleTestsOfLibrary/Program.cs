using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_games_input_parser_library;

namespace ConsoleTestsOfLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            input_parser parser = new input_parser();
            Console.WriteLine("Type in your test input string: ");
            //string testInput0 = Console.ReadLine();
            string testInput0 = "one two three four";
            string testInput1 = "    to one,two three  I,i THE*the a A  %^%^^  & $#{}|\\the,A:{}I TO    four   don't pick-up.five    SIX SEVEN%#$@!!()   ";
            string testInput2 = " ";
            string testInput3 = "";
            string testInput4 = null;
            string testInput5 = "I really,really waNT to take the FLOWERS.";
            string testInput6 = "        tAkE#$%&%^&,>.?/fLOwers    &*()DrOp    SEEds";
            string testInput7 = "&*()DrOp    SEEds        tAkE#$%&%^&,>.?/fLOwers    ";
            string testInput8 = "&*()LeaVE    SEEds        blankblank#$%&%^&,>.?/fLOwers    ";
            string testInput9 = "&*()blankblank    SEEds        coLLEct#$%&%^&,>.?/fLOwers    ";
            string testInput10 = " TAKE drop pick-up LEAVE collect";
            string testInput11 = "        pIcK-Up#$%&%^&,>.?/fLOwers    &*()LEaVe    SEEds";
            string testInput12 = "&*()LEaVe    SEEds        pIcK-Up#$%&%^&,>.?/fLOwers    ";
            string testInput13 = "&*()LEaVe    SEEds        pIcK-Up#$%&%^&,>.?/fLOwers    Take";
            string testInput14 = "pick-up water and food LEAVE TENT,CAR coLLecT fire-wood+TIndER DrOp_ropes";
            string testInput18 = "pick-up water and food LEAVE TENT,CAR()*&^and Go to THE_woodS coLLecT fire-wood+TIndER RUN to the RiVer DrOp_ropes waLK to the HILLS";
            string testInput19 = "zero take one two three four";
            string testInput20 = "zero1 zero2 take one two three four collect 1 2 3 4";
            string testInput21 = "pick-up zero1 zero2 take one two three four collect 1 2 3 4";



            parser.ParseTextInput(testInput21);


            
            //Console.ReadLine();
        }
    }
}
