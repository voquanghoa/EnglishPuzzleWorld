using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Excel2Json
{
	[DataContract]
	public class Question
	{
		[DataMember(Name = "title")]
		public string Title
		{
			get; set;
		}

		[DataMember(Name = "answer")]
		public string Answer
		{
			get; set;
		}
	}
	[DataContract]
	public class Category
	{
		[DataMember(Name = "name")]
		public string Name
		{
			get; set;
		}

		[DataMember(Name = "questions")]
		public List<Question> Questions
		{
			get; set;
		}

		public Category()
		{
			Questions = new List<Question>();
		}
	}
	[DataContract]
	public class Data : List<Category>
	{

	}
}
