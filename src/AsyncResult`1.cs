namespace Icod { 

	/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult`1"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public abstract class AsyncResult<R> : Icod.AsyncResult, Icod.IAsyncResult<R> { 

		#region fields
		private R myResult;
		#endregion fields


		#region .ctor
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult`1"]/member[@name="#ctor(System.AsyncCallback,System.Object)"]/*'/>
		protected AsyncResult( System.AsyncCallback callback, System.Object asyncState ) : base( callback, asyncState ) { 
		}
		#endregion .ctor


		#region properties
		R Icod.IAsyncResult<R>.Result { 
			get { 
				return this.Result;
			}
		}
		public R Result { 
			get { 
				return myResult;
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult`1"]/member[@name="SetCompletion(`0,System.Boolean,System.Exception)"]/*'/>
		protected void SetCompletion( R result, System.Boolean completedSynchronously, System.Exception completionException ) { 
			myResult = result;
			base.SetCompletion( completedSynchronously, completionException );
		}
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.AsyncResult`1"]/member[@name="EndInvoke"]/*'/>
		new protected R EndInvoke() { 
			base.EndInvoke();
			return myResult;
		}
		#endregion methods

	}

}