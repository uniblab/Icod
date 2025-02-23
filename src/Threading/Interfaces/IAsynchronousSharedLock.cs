namespace Icod.Threading { 

	/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public interface IAsynchronousSharedLock : ISynchronousSharedLock { 

		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="BeginWrite(System.AsyncCallback,System.Object)"]/*'/>
		System.IAsyncResult BeginExclude( System.AsyncCallback callback, System.Object state );
		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="EndWrite(System.IAsyncResult)"]/*'/>
		System.IDisposable EndExclude( System.IAsyncResult result );

		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="BeginRead(System.AsyncCallback,System.Object)"]/*'/>
		System.IAsyncResult BeginShare( System.AsyncCallback callback, System.Object state );
		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.IAsynchronousSharedLock"]/member[@name="EndRead(System.IAsyncResult)"]/*'/>
		System.IDisposable EndShare( System.IAsyncResult result );

	}

}