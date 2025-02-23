namespace Icod.Data { 

	/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class DataEnumerator<T> : IDataEnumerator<T> where T : IDataReadable, new() { 

		#region fields
		private System.Boolean disposed;
		private System.Data.Common.DbCommand myCommand;
		private System.Data.IDataReader myReader;
		private System.Data.CommandBehavior myBehaviour;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="#ctor(System.Data.Common.DbCommand)"]/*'/>
		internal DataEnumerator( System.Data.Common.DbCommand command ) : this( command, System.Data.CommandBehavior.SingleResult ) { 
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="#ctor(System.Data.Common.DbCommand,System.Data.CommandBehavior)"]/*'/>
		internal DataEnumerator( System.Data.Common.DbCommand command, System.Data.CommandBehavior behaviour ) : this() { 
			if ( null == command ) { 
				throw new System.InvalidOperationException();
			}
			myCommand = command;
			myBehaviour = behaviour;
			myReader = command.ExecuteReader( myBehaviour );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="#ctor"]/*'/>
		protected DataEnumerator() { 
			disposed = false;
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Finalize"]/*'/>
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", 
			"CA1063:ImplementIDisposableCorrectly", 
			Justification = "the analysis suggests I do *exactly* as I am doing" 
		)]
		~DataEnumerator() { 
			this.Dispose( false );
		}
		#endregion .ctor


		#region properties
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Current"]/*'/>
		System.Object System.Collections.IEnumerator.Current { 
			get { 
				return ((System.Collections.Generic.IEnumerator<T>)this).Current;
			}
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Current"]/*'/>
		public T Current { 
			get { 
				if ( ( null == myReader ) || ( true == myReader.IsClosed ) ) { 
					throw new System.InvalidOperationException( );
				} else { 
					T output = new T();
					output.ReadFrom( myReader );
					return output;
				}
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="MoveNext"]/*'/>
		public System.Boolean MoveNext() { 
			return myReader.Read();
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Reset"]/*'/>
		public void Reset() { 
			if ( null != myReader ) { 
				myReader.Dispose();
			}
			if ( null == myCommand ) { 
				throw new System.InvalidOperationException();
			}
			myReader = myCommand.ExecuteReader( myBehaviour );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Dispose"]/*'/>
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", 
			"CA1063:ImplementIDisposableCorrectly", 
			Justification = "the analysis suggests I do *exactly* as I am doing" 
		)]
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Dispose(System.Boolean)"]/*'/>
		protected virtual void Dispose( System.Boolean disposing ) { 
			lock ( this ) { 
				if ( false == disposed ) { 
					if ( null != myReader ) { 
						myReader.Dispose();
					}
					if ( true == disposing ) { 
						myReader = null;
					}
					disposed = true;
				}
			}
		}
		#endregion methods

	}

}