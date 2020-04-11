package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("Bovie.Droid.MainApplication, Bovie.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64c1d77d7ae375923f.MainApplication.class, crc64c1d77d7ae375923f.MainApplication.__md_methods);
		
	}
}
