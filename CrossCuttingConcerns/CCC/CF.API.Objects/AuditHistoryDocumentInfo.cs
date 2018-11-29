using System;
using System.Collections.Generic;

namespace CF.API.Objects
{
	public class AuditHistoryDocumentInfo
	{

		#region Fields / Properties

		public string	OriginalSourceDataFile			{ get; set;}
		public string	ModifiedSourceDataFile			{ get; set;}
		public string	ReceivedFromEmail					{ get; set; }
		public string	InitialReceiveProcessedBy			{ get; set; }
		public DateTime InitialReceiveProcessedDate		{ get; set; }
		public string	ModifyReceiveProcessedBy			{ get; set;}
		public DateTime ModifiedReceiveProcessedDate	{ get; set; }
		public string		Notes								{ get; set;}
		public string		FileType							{ get; set;}
		public DateTime?		ProcessingDueDate				{ get; set; }
		public DateTime? ProcessingCompleteDate			{ get; set; }
		
		public int PeriodEntryYear	{ get; set; }
		public int PeriodEntryMonth	{ get; set; }

		public string PeriodEntry
		{
			get
			{	
				if (PeriodEntryMonth > 0 && PeriodEntryMonth < 13 && PeriodEntryYear > 1998)
				{
					DateTime dt = new DateTime(PeriodEntryYear, PeriodEntryMonth, 1);
					return dt.ToString("yyyy-MM");
				}
				else
				{
					return string.Empty;
				}
			}
		}


		#endregion

		#region Constructors

		public AuditHistoryDocumentInfo()
		{
		}

		#endregion

		#region Methods

		public bool IsEmpty()
		{
			bool retValue = true;
				
			string checkEmpty = OriginalSourceDataFile ??
									ModifiedSourceDataFile ??
									ReceivedFromEmail ??
									InitialReceiveProcessedBy ?? 
									//InitialReceiveProcessedDate ?? 
									ModifyReceiveProcessedBy ?? 
									//ModifiedReceiveProcessedDate ?? 
									Notes ??
									//ProcessingDueDate ?? 
									//ProcessingCompleteDate ??
									FileType;


			if (checkEmpty != null && checkEmpty.Length > 0)
				retValue = false;	
							
			return retValue;

		}
		#endregion
	}

	public class AuditHistoryDocumentInfoComparer : IEqualityComparer<AuditHistoryDocumentInfo>
	{
		// AuditHistoryDocumentInfo are equal if their Year/Month/OriginalFileName/ModifiedFileName are equal. 
		public bool Equals(AuditHistoryDocumentInfo x, AuditHistoryDocumentInfo y)
		{
			//Check whether the compared objects reference the same data. 
			if (Object.ReferenceEquals(x, y)) return true;

			//Check whether any of the compared objects is null. 
			if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
				return false;

			//Check whether the products' properties are equal. 
			//return x.Code == y.Code && x.Name == y.Name;
			return x.PeriodEntryYear == y.PeriodEntryYear
					&& x.PeriodEntryMonth == y.PeriodEntryMonth
						&& x.OriginalSourceDataFile == y.OriginalSourceDataFile
								&& x.ModifiedSourceDataFile == y.ModifiedSourceDataFile; 
		}

		// If Equals() returns true for a pair of objects  
		// then GetHashCode() must return the same value for these objects. 
public int GetHashCode(AuditHistoryDocumentInfo sourceDoc)
		{
			//Check whether the object is null 
			if (Object.ReferenceEquals(sourceDoc, null)) return 0;

			//Get hash code for the key fields.
			int hashPeriodEntryYear		= sourceDoc.PeriodEntryYear.GetHashCode();
			int hashPeriodEntryMonth	= sourceDoc.PeriodEntryMonth.GetHashCode();
			int hashOrigFile			= sourceDoc.OriginalSourceDataFile == null ? 0 : sourceDoc.OriginalSourceDataFile.GetHashCode();
			int hashModFile				= sourceDoc.ModifiedSourceDataFile == null ? 0 : sourceDoc.ModifiedSourceDataFile.GetHashCode();

			//Calculate the hash code for the sourceDoc. 
			return hashPeriodEntryYear ^ hashPeriodEntryMonth ^ hashOrigFile ^ hashModFile;
		}

	}



}