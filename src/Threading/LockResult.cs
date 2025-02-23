namespace Icod.Threading { 

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	internal class LockResult : Icod.AsyncResult<System.IDisposable> { 

		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name="#ctor(System.AsyncCallback,System.Object)"]/*'/>
		internal LockResult( System.AsyncCallback callback, System.Object asyncState ) : base( callback, asyncState ) { 
		}
		#endregion .ctor


		#region methods
		internal void SetSynchronousCopmpletion( System.Boolean synchronous ) { 
			base.SetCompletedSynchronously( synchronous );
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name="SetCompletion(R,System.Boolean,System.Exception)"]/*'/>
		internal void Complete( System.IDisposable result, System.Boolean completedSynchronously, System.Exception completionException ) { 
			base.SetCompletion( result, completedSynchronously, completionException );
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name="SetCompletion(System.Boolean,System.Exception)"]/*'/>
		internal void Complete( System.Boolean completedSynchronously, System.Exception completionException ) { 
			base.SetCompletion( completedSynchronously, completionException );
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockResult"]/member[@name="EndInvoke"]/*'/>
		internal System.IDisposable End() { 
			return base.EndInvoke();
		}
		#endregion methods

	}

}