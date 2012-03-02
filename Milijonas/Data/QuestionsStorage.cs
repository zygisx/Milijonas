using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milijonas.Logic;
using System.Xml.Linq;
using System.Configuration;
using System.Xml;

namespace Milijonas.Data
{
    /**
     * for now methods are static 
     * 
     */

    public class QuestionsStorage
    {
        public const string XML_FILE_PATH = @"data\Questions.xml";
        
       

        public QuestionsStorage(string fileName)
        {
            //ToDo Do smth with unused param in constructor
            //this.XmlDoc = XDocument.Load(@XML_FILE_PATH);
        }

        public static Question GetRandomQuestion(Stage stage) 
        {
            XDocument XmlDoc = XDocument.Load(XML_FILE_PATH);

            var result = from question in XmlDoc.Descendants("task")
                         where (int)question.Attribute("stage") == (int)stage
                         select question;

            int numberOfQuestions = result.Count();
            Random rand = new Random();
            int index = rand.Next(numberOfQuestions);
            var element = result.ElementAt(index);
            

            return new Question()
            {
                Problem = (string) element.Element("question").Value,
                Answer = (string) element.Element("answer").Value,
                Case1 = (string) element.Element("case1").Value,
                Case2 = (string) element.Element("case2").Value
            };
        }

        public static void AppendQuestions(string question,
            string answer, string case1, string case2, string difficulty)
        {
            try {

                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.Load(XML_FILE_PATH);
                XmlElement newElem = XmlDoc.CreateElement("task");

                XmlAttribute difficultyAttribute = XmlDoc.CreateAttribute("stage");
                difficultyAttribute.Value = difficulty;
                newElem.Attributes.Append(difficultyAttribute);

                newElem.InnerXml = "<question></question><answer></answer><case1></case1><case2></case2>";
                //XmlText txtNode = XmlDoc.CreateTextNode("A BRIEF HISTORY OF TIME");
                //newElem.FirstChild.AppendChild(txtNode);
                //newElem.AppendChild(doc.CreateWhitespace("\r\n")); // Linefeed
                newElem["question"].InnerText = question;
                newElem["answer"].InnerText = answer;
                newElem["case1"].InnerText = case1;
                newElem["case2"].InnerText = case2;

                XmlDoc.DocumentElement.LastChild.AppendChild(newElem);
                XmlDoc.Save(XML_FILE_PATH);
            }
            catch (XmlException xmlEx)        // Handle the Xml exceptions here.         
            {
                Console.WriteLine("{0}", xmlEx.Message);
            }
        }
    }
}
