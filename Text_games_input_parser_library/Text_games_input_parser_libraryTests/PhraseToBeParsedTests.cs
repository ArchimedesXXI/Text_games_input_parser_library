using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Text_games_input_parser_library;

namespace Text_games_input_parser_libraryTests
{

    [TestClass]
    public class PhraseToBeParsedTests
    {
        [TestMethod]
        public void UpdateProperty_ItemsCorrespondingToKeyWords_TESTinputEmptyString()
        {
            string inputData = "";
            var expectedResult = new Dictionary<string, List<string>>() 
                { 
                    { "take", new List<string>() }, 
                    { "drop", new List<string>() }
                };
            PhraseToBeParsed phrase = new PhraseToBeParsed(inputData);
 
            foreach (string key in expectedResult.Keys)
            {
                Assert.AreEqual(expectedResult[key].Count, phrase.ItemsCorrespondingToKeyWords[key].Count);
                for (int i = 0; i < phrase.ItemsCorrespondingToKeyWords[key].Count; i++)
                    Assert.AreEqual(expectedResult[key][i], phrase.ItemsCorrespondingToKeyWords[key][i]);
            }
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void UpdateProperty_ItemsCorrespondingToKeyWords_TESTinputIsNull()
        {
            new PhraseToBeParsed(null);
        }

        [TestMethod]
        public void UpdateProperty_ItemsCorrespondingToKeyWords_TEST00()
        {
            string inputData = "one two three four";
            var expectedResult = new Dictionary<string, List<string>>() 
                { 
                    { "take", new List<string>() }, 
                    { "drop", new List<string>() }
                };
            PhraseToBeParsed phrase = new PhraseToBeParsed(inputData);

            foreach (string key in expectedResult.Keys)
            {
                Assert.AreEqual(expectedResult[key].Count, phrase.ItemsCorrespondingToKeyWords[key].Count);
                for (int i = 0; i < phrase.ItemsCorrespondingToKeyWords[key].Count; i++)
                    Assert.AreEqual(expectedResult[key][i], phrase.ItemsCorrespondingToKeyWords[key][i]);
            }
        }

        [TestMethod]
        public void UpdateProperty_ItemsCorrespondingToKeyWords_TEST13()
        {
            string inputData = "&*()LEaVe    SEEds        pIcK-Up#$%&%^&,>.?/fLOwers    Take";
            var expectedResult = new Dictionary<string, List<string>>() 
                { 
                    { "take", new List<string>() {"flowers"} }, 
                    { "drop", new List<string>() {"seeds"} }
                };
            PhraseToBeParsed phrase = new PhraseToBeParsed(inputData);

            foreach (string key in expectedResult.Keys)
            {
                Assert.AreEqual(expectedResult[key].Count, phrase.ItemsCorrespondingToKeyWords[key].Count);
                for (int i = 0; i < phrase.ItemsCorrespondingToKeyWords[key].Count; i++)
                    Assert.AreEqual(expectedResult[key][i], phrase.ItemsCorrespondingToKeyWords[key][i]);
            }
        }

        [TestMethod]
        public void UpdateProperty_ItemsCorrespondingToKeyWords_TEST14()
        {
            string inputData = "pick-up water and food LEAVE TENT,CAR coLLecT fire-wood+TIndER DrOp_ropes";
            var expectedResult = new Dictionary<string, List<string>>() 
                { 
                    { "take", new List<string>() {"water", "food", "fire-wood", "tinder"} }, 
                    { "drop", new List<string>() {"tent", "car", "ropes"} }
                };
            PhraseToBeParsed phrase = new PhraseToBeParsed(inputData);

            foreach (string key in expectedResult.Keys)
            {
                Assert.AreEqual(expectedResult[key].Count, phrase.ItemsCorrespondingToKeyWords[key].Count);
                for (int i = 0; i < phrase.ItemsCorrespondingToKeyWords[key].Count; i++)
                    Assert.AreEqual(expectedResult[key][i], phrase.ItemsCorrespondingToKeyWords[key][i]);
            }
        }

        [TestMethod]
        public void UpdateProperty_ItemsCorrespondingToKeyWords_TEST15()
        {
            string inputData = "Hello Martin. What I want you to do is to PICK-up flowers and grass, and LEAVE grass-seeds,flower-SEEDS+SUNshine. And collect a TREE!";
            var expectedResult = new Dictionary<string, List<string>>()
                {
                    { "take", new List<string> {"flowers", "grass", "tree"} },
                    { "drop", new List<string> {"grass-seeds", "flower-seeds", "sunshine"} }
                };
            PhraseToBeParsed phrase = new PhraseToBeParsed(inputData);

            foreach (string key in expectedResult.Keys)
            {
                Assert.AreEqual(expectedResult[key].Count, phrase.ItemsCorrespondingToKeyWords[key].Count);
                for (int i = 0; i < phrase.ItemsCorrespondingToKeyWords[key].Count; i++)
                    Assert.AreEqual(expectedResult[key][i], phrase.ItemsCorrespondingToKeyWords[key][i]);
            }
        }

        [TestMethod]
        public void UpdateProperty_ItemsCorrespondingToKeyWords_TEST16()
        {
            string inputData = "leave take pick-up";
            var expectedResult = new Dictionary<string, List<string>>()
                {
                    { "take", new List<string>() },
                    { "drop", new List<string>() }
                };
            PhraseToBeParsed phrase = new PhraseToBeParsed(inputData);

            foreach (string key in expectedResult.Keys)
            {
                Assert.AreEqual(expectedResult[key].Count, phrase.ItemsCorrespondingToKeyWords[key].Count);
                for (int i = 0; i < phrase.ItemsCorrespondingToKeyWords[key].Count; i++)
                    Assert.AreEqual(expectedResult[key][i], phrase.ItemsCorrespondingToKeyWords[key][i]);
            }
        }

        [TestMethod]
        public void UpdateProperty_ItemsCorrespondingToKeyWords_TEST17()
        {
            string inputData = @"&*()DrOp  ""   SEEds        tAkE#$%&%^&,>.?/fLOwers    ";
            var expectedResult = new Dictionary<string, List<string>>()
                {
                    { "go", new List<string>() },
                    { "take", new List<string> {"flowers"} },
                    { "drop", new List<string> {"seeds"} },
                };
            PhraseToBeParsed phrase = new PhraseToBeParsed(inputData);

            foreach (string key in expectedResult.Keys)
            {
                Assert.AreEqual(expectedResult[key].Count, phrase.ItemsCorrespondingToKeyWords[key].Count);
                for (int i = 0; i < phrase.ItemsCorrespondingToKeyWords[key].Count; i++)
                    Assert.AreEqual(expectedResult[key][i], phrase.ItemsCorrespondingToKeyWords[key][i]);
            }
        }

        [TestMethod]
        public void UpdateProperty_ItemsCorrespondingToKeyWords_TEST18()
        {
            string inputData = "pick-up water and food LEAVE TENT,CAR()*&^and Go to THE_woodS coLLecT fire-wood+TIndER RUN to the RiVer DrOp_ropes waLK to the HILLS";
            var expectedResult = new Dictionary<string, List<string>>()
                {
                    { "go", new List<string>() {"woods", "river", "hills"} },
                    { "take", new List<string>() {"water", "food", "fire-wood", "tinder"} }, 
                    { "drop", new List<string>() {"tent", "car", "ropes"} }
                };
            PhraseToBeParsed phrase = new PhraseToBeParsed(inputData);

            foreach (string key in expectedResult.Keys)
            {
                Assert.AreEqual(expectedResult[key].Count, phrase.ItemsCorrespondingToKeyWords[key].Count);
                for (int i = 0; i < phrase.ItemsCorrespondingToKeyWords[key].Count; i++)
                    Assert.AreEqual(expectedResult[key][i], phrase.ItemsCorrespondingToKeyWords[key][i]);
            }
        }


    }
}
