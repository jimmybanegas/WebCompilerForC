using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Lexer.Specs
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"the following source code")]
        public void GivenTheFollowingSourceCode(SourceCode sourceCode)
        {
            var lexer = new Lexer(sourceCode);
            ScenarioContext.Current.Add("lexer", lexer);
            ScenarioContext.Current.Add("sourceCode", sourceCode);
        }
        
        [When(@"I get the next token")]
        public void WhenIGetTheNextToken()
        {
            var lexer = ScenarioContext.Current.Get<Lexer>("lexer");
            var nextToken = lexer.GetNextToken();
            ScenarioContext.Current.Add("nextToken", nextToken);
        }

        [Then(@"the token should be of type (.*)")]
        public void ThenTheTokenShouldBeOfType(string tokenTypeName)
        {
            var nextToken = ScenarioContext.Current.Get<Token>("nextToken");
            Assert.AreEqual(tokenTypeName, nextToken.TokenType.ToString());
        }
    }
}
