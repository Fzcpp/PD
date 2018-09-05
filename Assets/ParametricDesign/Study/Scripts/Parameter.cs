﻿public class Parameter<T>
{

	public T Value;

	public object  GetRef()
	{
		return this;
	}

	public float GetSum(float op1, float op2)
	{
		return op1 + op2;
	}

    public T GetValue()
    {
        return Value;
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