using NUnit.Framework;
using Kent.Boogaart.Converters.Expressions;
using Kent.Boogaart.Converters.Expressions.Nodes;

namespace Kent.Boogaart.Converters.UnitTest.Expressions.Nodes
{
	[TestFixture]
	public sealed class ConditionalNodeTest : UnitTest
	{
		private MockConditionalNode _conditionalNode;

		[Test]
		[ExpectedException(typeof(ParseException), ExpectedMessage = "Operator 'op' cannot be applied to operands of type 'Boolean' and 'Int32'.")]
		public void Evaluate_ShouldThrowIfTypesArentBoolean1()
		{
			_conditionalNode = new MockConditionalNode(new ConstantNode<bool>(false), new ConstantNode<int>(0));
			_conditionalNode.Evaluate(NodeEvaluationContext.Empty);
		}

		[Test]
		[ExpectedException(typeof(ParseException), ExpectedMessage = "Operator 'op' cannot be applied to operands of type 'Int32' and 'Boolean'.")]
		public void Evaluate_ShouldThrowIfTypesArentBoolean2()
		{
			_conditionalNode = new MockConditionalNode(new ConstantNode<int>(1), new ConstantNode<bool>(false));
			_conditionalNode.Evaluate(NodeEvaluationContext.Empty);
		}

		[Test]
		public void Evaluate_ShouldOnlyEvaluateRightNodeIfNecessary()
		{
			_conditionalNode = new MockConditionalNode(new ConstantNode<bool>(false), new ConstantNode<bool>(false));
			_conditionalNode.PreRightEvaluationResult = true;
			Assert.AreEqual(true, _conditionalNode.Evaluate(NodeEvaluationContext.Empty));
			Assert.IsTrue(_conditionalNode.PreRightEvaluationDetermineResultCalled);
			Assert.IsFalse(_conditionalNode.PostRightEvaluationDetermineResultCalled);

			_conditionalNode.PreRightEvaluationResult = null;
			_conditionalNode.PostRightEvaluationResult = true;
			Assert.AreEqual(true, _conditionalNode.Evaluate(NodeEvaluationContext.Empty));
			Assert.IsTrue(_conditionalNode.PreRightEvaluationDetermineResultCalled);
			Assert.IsTrue(_conditionalNode.PostRightEvaluationDetermineResultCalled);
		}

		#region Supporting Types

		private sealed class MockConditionalNode : ConditionalNode
		{
			public bool? PreRightEvaluationResult;
			public bool PostRightEvaluationResult;
			public bool PreRightEvaluationDetermineResultCalled;
			public bool PostRightEvaluationDetermineResultCalled;

			protected override string OperatorSymbols
			{
				get
				{
					return "op";
				}
			}

			public MockConditionalNode(Node leftNode, Node rightNode)
				: base(leftNode, rightNode)
			{
			}

			protected override bool? DetermineResultPreRightEvaluation(bool leftResult)
			{
				PreRightEvaluationDetermineResultCalled = true;
				return PreRightEvaluationResult;
			}

			protected override bool DetermineResultPostRightEvaluation(bool leftResult, bool rightResult)
			{
				PostRightEvaluationDetermineResultCalled = true;
				return PostRightEvaluationResult;
			}
		}

		#endregion
	}
}