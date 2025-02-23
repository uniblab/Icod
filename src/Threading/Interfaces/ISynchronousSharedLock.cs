namespace Icod.Threading { 

	/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousSharedLock"]/member[@name=""]/*'/>
	public interface ISynchronousSharedLock : ISynchronousLock { 

		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousSharedLock"]/member[@name="Share"]/*'/>
		System.IDisposable Share();

		/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousSharedLock"]/member[@name="Exclude"]/*'/>
		System.IDisposable Exclude();

	}

}