public class Parameter<T>
{

	public T Value;

	public Parameter<T> GetRef()
	{
		return this;
	}


}


public class TestData
{
	public string AAA;
	public int BBB;
}

public class TestDataParameter : Parameter<TestData>
{
	public TestDataParameter()
	{
		
	}
	public TestDataParameter(string aaa,int bbb)
	{
		Value = new TestData();
		Value.AAA = aaa;
		Value.BBB = bbb;
	}
}