namespace Icod.Threading { 

	/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousLock"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public interface IAsynchronousLock : ISynchronousLock { 

		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousLock"]/member[@name="BeginAcquire"]/*'/>
		System.IAsyncResult BeginAcquire( System.AsyncCallback callback, System.Object state );
		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousLock"]/member[@name="EndAcquire"]/*'/>
		System.IDisposable EndAcquire( System.IAsyncResult result );

	}

}