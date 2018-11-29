namespace CF.API.Objects
{
	public class CommentaryData
	{
		public CommentaryData()
		{
		}

		public string Key				{ get; set;}
		
		public string	Company			{ get; set; }
		public string	Period			{ get; set; }
		public int		SectionNumber	{ get; set; }
		public int		UdfNumber		{ get; set; }
		public bool		ConvertToText	{ get; set; }
		//public string Email		{ get; set; }

		public object Value			{ get; set; }

	}
}
