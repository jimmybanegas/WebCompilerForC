Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: First call to GetNextToken yields valid token
	Given the following source code
	"""
	count = 12 + A;
	"""
	When I get the next token
	Then the token should be of type Identifier

@mytag
Scenario: SecondCall to GetNextToken yields a different token
	Given the following source code
	"""
	12 + A;
	"""
	When I get the next token
	Then the token should be of type Number
