namespace Icod.Data { 

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataStore`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public interface IDataStore<T> : System.IDisposable { 

		/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataStore`1"]/member[@name="DataConnection"]/*'/>
		System.Data.Common.DbConnection DataConnection { 
			get;
		}

		/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataStore`1"]/member[@name="Behaviour"]/*'/>
		System.Data.CommandBehavior Behaviour { 
			get;
		}

	}

}