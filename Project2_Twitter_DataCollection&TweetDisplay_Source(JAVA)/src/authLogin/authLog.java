package authLogin;

import java.awt.Desktop;
import mainLaunch.Log_In_Auth;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.MalformedURLException;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.URL;
import java.util.Properties;

import javax.sound.sampled.Line;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

import MainApp.MainScreen;
import twitter4j.Status;
import twitter4j.Twitter;
import twitter4j.TwitterException;
import twitter4j.TwitterFactory;
import twitter4j.auth.AccessToken;
import twitter4j.auth.RequestToken;

public class authLog {
	
	
	//Authorize Login
	public static void Authorize_User() {
		  String[] args = new String[1];
		  // The factory instance is re-usable and thread safe.
		    Twitter twitter = TwitterFactory.getSingleton();
		    twitter.setOAuthConsumer("aBCxWCrfYOFimU2FNUOc48tHS", "V9ngbgGckBNXr98bDepqvsMTPmVzeQaztNetsAoNul21d9Gobj");
		    RequestToken requestToken;
			try {
				requestToken = twitter.getOAuthRequestToken();
				AccessToken accessToken = null;
			    BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
			    while (null == accessToken) {
			      System.out.println("Open the following URL and grant access to your account:");
			      System.out.println(requestToken.getAuthorizationURL());
			      URL tempURL = new URL(requestToken.getAuthorizationURL());
			      openWebpage(tempURL);
			      System.out.print("Enter the PIN(if aviailable) or just hit enter.[PIN]:");
			      String pin;
			      String path = JOptionPane.showInputDialog("Enter your PIN");
			      pin = path;
			try{
				 if(pin.length() > 0){
				   accessToken = twitter.getOAuthAccessToken(requestToken, pin);
				 }else{
				   accessToken = twitter.getOAuthAccessToken();
				 }
			} catch (TwitterException te) {
				if(401 == te.getStatusCode()){
				  System.out.println("Unable to get the access token.");
				}else{
				  te.printStackTrace();
				}
			}
			     
			    }
				storeAccessToken(twitter.verifyCredentials().getId() , accessToken);
			
			
			} catch (TwitterException | MalformedURLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		    
		    //persist to the accessToken for future reference.

		    
		  }
	
	 private static void storeAccessToken(long useId, AccessToken accessToken){
		// try {
		      //File myObj = new File("accessToken.txt");
		     // if (myObj.createNewFile()) {
		     //System.out.println("File created: " + myObj.getName());
		       // try {
			     /*  // FileWriter myWriter = new FileWriter("accessToken.txt");
			        // myWriter.write("User AccessToken: " + accessToken.getToken());
			        // myWriter.write(accessToken.getToken());
			        // myWriter.write("User AccessToken Secret: " + accessToken.getTokenSecret());
			        // myWriter.close();
			        //FileWriter myWriter2 = new FileWriter("tokenSecret.txt");
			        //  myWriter2.write(accessToken.getTokenSecret());
			        //  myWriter2.close();*/
			          try (OutputStream output = new FileOutputStream("twitter4j.properties")) {

			              Properties prop = new Properties();

			              // set the properties value
			              prop.setProperty("debug", "true");
			              prop.setProperty("oauth.consumerKey", "aBCxWCrfYOFimU2FNUOc48tHS");
			              prop.setProperty("oauth.consumerSecret", "V9ngbgGckBNXr98bDepqvsMTPmVzeQaztNetsAoNul21d9Gobj");
			              prop.setProperty("oauth.accessToken", accessToken.getToken());
			              prop.setProperty("oauth.accessTokenSecret", accessToken.getTokenSecret());

			              // save properties to project root folder
			              prop.store(output, null);
			              
			              System.out.println(prop);
			              System.out.println("Successfully wrote to the file.");
				          MainScreen mainview = new MainScreen();
				          mainview.show(true);
					      

			          } catch (IOException io) {
			              io.printStackTrace();
			          }

			          //TXT VERSION
			          /*FileWriter myWriter3 = new FileWriter("src\\twitter4j.properties.txt");
			          myWriter3.write("debug=true");
			          myWriter3.write("\n");
			          myWriter3.write("oauth.consumerKey=aBCxWCrfYOFimU2FNUOc48tHS");
			          myWriter3.write("\n");
			          myWriter3.write("oauth.consumerSecret=V9ngbgGckBNXr98bDepqvsMTPmVzeQaztNetsAoNul21d9Gobj");
			          myWriter3.write("\n");
			          myWriter3.write("oauth.accessToken=" + accessToken.getToken());
			          myWriter3.write("\n");
			          myWriter3.write("oauth.accessToken=" + accessToken.getTokenSecret());
			          myWriter3.close();
			          System.out.println("Successfully wrote to the file.");
			          System.exit(0);*/
			     /*   } catch (IOException e) {
			          System.out.println("An error occurred.");
			          e.printStackTrace();*/
			        }	      
		       /*else {
		    	  
		        System.out.println("File already exists.");
		        JFrame jFrame = new JFrame();
		        JOptionPane.showMessageDialog(jFrame, "Authorization Already Exists, Loging in...");
		      }*/
		      
		  //  } catch (IOException e) {
		  //    System.out.println("An error occurred.");
		  //    e.printStackTrace();
		 //   }
		 	//store accessToken.getToken()
		    //store accessToken.getTokenSecret()

	
		    
		  
	
	
	public static boolean openWebpage(URI uri) {
	    Desktop desktop = Desktop.isDesktopSupported() ? Desktop.getDesktop() : null;
	    if (desktop != null && desktop.isSupported(Desktop.Action.BROWSE)) {
	        try {
	            desktop.browse(uri);
	            return true;
	        } catch (Exception e) {
	            e.printStackTrace();
	        }
	    }
	    return false;
	}
	
	
	public static boolean openWebpage(URL url) {
	    try {
	        return openWebpage(url.toURI());
	    } catch (URISyntaxException e) {
	        e.printStackTrace();
	    }
	    return false;
	}
	

		
}
