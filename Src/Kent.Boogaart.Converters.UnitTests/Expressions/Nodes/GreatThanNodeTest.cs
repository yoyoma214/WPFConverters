using Kent.Boogaart.Converters.Expressions.Nodes;
using Xunit;

namespace Kent.Boogaart.Converters.UnitTests.Expressions.Nodes
{
    public sealed class GreatThanNodeTest : WideningBinaryNodeTestBase
    {
        private GreaterThanNode greaterThanNode;

        protected override void SetUpCore()
        {
            base.SetUpCore();
            this.greaterThanNode = new GreaterThanNode(new ConstantNode<int>(0), new ConstantNode<int>(0));
        }

        [Fact]
        public void OperatorSymbols_ShouldYieldCorrectOperatorSymbols()
        {
            Assert.Equal(">", GetPrivateMemberValue<string>(this.greaterThanNode, "OperatorSymbols"));
        }

        [Fact]
        public void DoByte_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoByte", (byte)1, (byte)2));
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoByte", (byte)2, (byte)2));
            Assert.True(InvokeDoMethod<bool>(this.greaterThanNode, "DoByte", (byte)3, (byte)2));
        }

        [Fact]
        public void DoInt16_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoInt16", (short)1, (short)2));
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoInt16", (short)2, (short)2));
            Assert.True(InvokeDoMethod<bool>(this.greaterThanNode, "DoInt16", (short)3, (short)2));
        }

        [Fact]
        public void DoInt32_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoInt32", 1, 2));
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoInt32", 2, 2));
            Assert.True(InvokeDoMethod<bool>(this.greaterThanNode, "DoInt32", 3, 2));
        }

        [Fact]
        public void DoInt64_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoInt64", 1L, 2L));
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoInt64", 2L, 2L));
            Assert.True(InvokeDoMethod<bool>(this.greaterThanNode, "DoInt64", 3L, 2L));
        }

        [Fact]
        public void DoSingle_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoSingle", 1f, 2f));
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoSingle", 2f, 2f));
            Assert.True(InvokeDoMethod<bool>(this.greaterThanNode, "DoSingle", 3f, 2f));
        }

        [Fact]
        public void DoDouble_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoDouble", 1d, 2d));
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoDouble", 2d, 2d));
            Assert.True(InvokeDoMethod<bool>(this.greaterThanNode, "DoDouble", 3d, 2d));
        }

        [Fact]
        public void DoDecimal_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoDecimal", 1m, 2m));
            Assert.False(InvokeDoMethod<bool>(this.greaterThanNode, "DoDecimal", 2m, 2m));
            Assert.True(InvokeDoMethod<bool>(this.greaterThanNode, "DoDecimal", 3m, 2m));
        }
    }
}