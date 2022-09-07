package MainApp;

import authLogin.authLog;
import mainLaunch.Log_In_Auth;
import MainApp.DisplayTweet;
import java.awt.BorderLayout;
import java.awt.Button;
import java.awt.EventQueue;
import java.awt.GridBagConstraints;
import java.awt.Insets;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.ObjectInputFilter.Status;
import java.net.MalformedURLException;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

import twitter4j.MediaEntity;
import twitter4j.Twitter;
import twitter4j.TwitterException;
import twitter4j.TwitterFactory;

import javax.swing.JScrollPane;
import javax.swing.SwingConstants;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.GridBagLayout;
import com.jgoodies.forms.layout.FormLayout;
import com.jgoodies.forms.layout.ColumnSpec;
import com.jgoodies.forms.layout.RowSpec;
import java.awt.CardLayout;
import java.awt.Color;
import java.awt.Desktop;
import java.awt.FlowLayout;
import javax.swing.BoxLayout;

public class MainScreen extends JFrame {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 * 
	 * 
	 * #########################################
	 * #########################################
	 * #########################################
	 * TO DO:
	 * AUTHD ONCE PROCEED TO MAIN SCREEN.
	 * ADD LIKE , RETWEET BUTTONS
	 * 
	 * #########################################
	 * #########################################
	 * #########################################
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					MainScreen frame = new MainScreen();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}
	
	
	public void GetTimeline(JPanel mainView) throws IOException {
		Twitter twitter = TwitterFactory.getSingleton();
	    List<twitter4j.Status> statuses;
	    GridBagConstraints gbc = new GridBagConstraints();
	    gbc.insets = new Insets(10,10,10,10);
	    int i = 0;
		try {
			statuses = twitter.getHomeTimeline();
			System.out.println("Showing home timeline.");
			JLabel[] tweets = new JLabel[statuses.size()];
			
			//Start Searching Tweets
		    for (twitter4j.Status status : statuses) {
		    	tweets[i] = new JLabel(status.getUser().getName() + ": " + status.getText());
		    	for(MediaEntity me : status.getMediaEntities()){
		    		URL twitterProfileImage = new URL(status.getUser().getProfileImageURL());
		    	    if(me.getMediaURLHttps() != null){//also check blank
		    	    	URL twitterImage = new URL(me.getMediaURL());
		    	    	DisplayTweet currentTweet = new DisplayTweet(tweets[i],  LikeTweet(status), ViewTweet(status), RetweetIt(status),twitterProfileImage, twitterImage);	
		    	    	gbc.gridy = i;
				    	mainView.add(currentTweet, gbc);
		    	    	}
		    	    else {
		    	    	DisplayTweet currentTweet = new DisplayTweet(tweets[i],  LikeTweet(status), ViewTweet(status), RetweetIt(status), twitterProfileImage);
		    	    	gbc.gridy = i;
				    	mainView.add(currentTweet, gbc);
		    	    }
		    	}
		    	
		     // tweets[i].setSize(3, 3);
		    //	mainView.add(tweets[i], gbc);
		    //	mainView.add(ViewTweet(status));
		    	i++;
		        System.out.println(status.getUser().getName() + ":" +
		                           status.getText());
		    		} 
		}catch (TwitterException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			}
		mainView.revalidate();
		mainView.repaint();
		
		}//end of GetTimeLine
	
	
	
	
	
	
	//View Tweetbutton
	public JButton ViewTweet(twitter4j.Status status) {
		JButton seeTweet = new JButton("See Tweet.");
		seeTweet.setBounds(5,5, 5, 5);
		seeTweet.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e){ 
				try {
					URL mpURL = new URL("https://twitter.com/" + (status.getUser().getName()).replaceAll("\\s+","") + "/status/" + status.getId());
					authLog.openWebpage(mpURL);
					/*mainView.add(seeTweet);
					mainView.revalidate();
					mainView.repaint();*/
				} catch (MalformedURLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			
			}//End of Action Listener
		
		
		});
		
	
			return seeTweet;
			//return null;
		}
	/*	seeTweet.addActionListener(new ActionListener()){  
			public void actionPerformed(ActionEvent e){  
				//https://twitter.com/[screen name of user]/status/[id of status]
				URL mpURL = new URL("https://twitter.com/" + status.getUser().getName() + "/" + status.getId());
				authLog.openWebpage(mpURL);    
			});
		*/
		
	
	
	//Like Button
	public JButton LikeTweet(twitter4j.Status status) {
		JButton LikeTweet = new JButton("Like.");
		LikeTweet.setBounds(5,5, 5, 5);
		Twitter twitter = TwitterFactory.getSingleton();
		LikeTweet.addActionListener(new ActionListener() {
		public void actionPerformed(ActionEvent e){ 
		try {
			LikeTweet.setBackground(Color.RED);
			twitter.createFavorite(status.getId());
		} catch (TwitterException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
			}
		}
		
		
		});
		
		return LikeTweet;
	}
	
	
	//Retweet Button
	public JButton RetweetIt(twitter4j.Status status) {
		JButton retweetit = new JButton("Retweet.");
		Twitter twitter = TwitterFactory.getSingleton();
		retweetit.setBounds(5,5, 5, 5);
		retweetit.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e){ 
				try {
					twitter.retweetStatus(status.getId());
				} catch (TwitterException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
		}	
			
		});
		
		return retweetit;
	}
	
	
	

	/**
	 * Create the frame.
	 */
	public MainScreen() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 1239, 910);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		setLocationRelativeTo(null);
		setResizable(false);
		contentPane.setLayout(null);
		
		JScrollPane mainTimeline = new JScrollPane();
		mainTimeline.setBounds(184, 0, 1029, 860);
		contentPane.add(mainTimeline);
		
		JPanel mainView = new JPanel();
		mainTimeline.setViewportView(mainView);
		GridBagLayout gbl_mainView = new GridBagLayout();
		gbl_mainView.columnWidths = new int[]{0};
		gbl_mainView.rowHeights = new int[]{0};
		gbl_mainView.columnWeights = new double[]{Double.MIN_VALUE};
		gbl_mainView.rowWeights = new double[]{Double.MIN_VALUE};
		mainView.setLayout(gbl_mainView);
		
		JButton getTimelineBTN = new JButton("Get Timeline");
		getTimelineBTN.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					GetTimeline(mainView);
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		getTimelineBTN.setBounds(0, 250, 179, 58);
		contentPane.add(getTimelineBTN);
		
		JButton getTweetsfromList = new JButton("Favourite Users Timeline");
		getTweetsfromList.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				List<String> usernames = new ArrayList<String>();
				getFavUsers(usernames);
				try {
					SearchFromList(usernames, mainView);
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		getTweetsfromList.setBounds(0, 182, 179, 58);
		contentPane.add(getTweetsfromList);
		
		JButton favUsers = new JButton("Set Favourite Users");
		favUsers.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				FavUsers log = new FavUsers();
				log.show(true);
				dispose();
			}
		});
		favUsers.setBounds(23, 125, 127, 46);
		contentPane.add(favUsers);
		
		
	}
	
	
	
	//Search from user specified list, for their tweets only.
	public void SearchFromList(List<String> favouriteUsers, JPanel mainView) throws IOException {
		 Twitter twitter = new TwitterFactory().getInstance();
		 GridBagConstraints gbc = new GridBagConstraints();
		 gbc.insets = new Insets(5,5,5,5);
		 int gbcCounter = 0;
		  try {
	            List<twitter4j.Status> statuses;
	            if (favouriteUsers.size() > 0) {
	                for(int i = 0; i < favouriteUsers.size(); i++) {
	                statuses = twitter.getUserTimeline(favouriteUsers.get(i));
	                JLabel[] tweets = new JLabel[statuses.size()];
	                System.out.println("Showing @" + favouriteUsers.get(i) + "'s user timeline.");
	                int y = 0;
		            for (twitter4j.Status status : statuses) {
		            	//DON'T SHOW RETEWETS OR COMMENTS/ REPLIES
		            	if(status.isRetweet() || !(status.getInReplyToScreenName() == null))
		            	{
		            		System.out.println("Retweet or Reply, won't show.");
		            		y++;
		            	}
		            	else {
		            	//Show tweets on time line
		            	tweets[y] = new JLabel(status.getUser().getName() + ": " + status.getText());
		            	URL twitterProfileImage = new URL(status.getUser().getProfileImageURL());
		            	//check for media entities
		            	
		            	if(status.getMediaEntities().length != 0) {
				    	for(MediaEntity me : status.getMediaEntities()){
				    	    if(me.getMediaURLHttps() != null){//also check blank
				    	    	URL twitterImage = new URL(me.getMediaURL());
				    	    	DisplayTweet currentTweet = new DisplayTweet(tweets[y],  LikeTweet(status), ViewTweet(status), RetweetIt(status), twitterProfileImage, twitterImage);	
				    	  		if(status.isFavorited()) {
				            		 //currentTweet.getClientProperty(LikeTweet(status));
				            			currentTweet.getComponent(5).setBackground(Color.RED);
				            		
				            		}//if status is liked paint button pink/red	
				    	    	gbc.gridy = gbcCounter;
						    	mainView.add(currentTweet, gbc);
						    	gbcCounter++;
				    	    	}
				    	    else {
				    	    	DisplayTweet currentTweet = new DisplayTweet(tweets[y],LikeTweet(status), ViewTweet(status), RetweetIt(status), twitterProfileImage);
				    	  		if(status.isFavorited()) {
				            		 //currentTweet.getClientProperty(LikeTweet(status));
				            			currentTweet.getComponent(5).setBackground(Color.RED);
				            		
				            		}//if status is liked paint button pink/red	
				    	    	gbc.gridy = gbcCounter;
				    	    	gbcCounter++;
						    	mainView.add(currentTweet, gbc);
				    	    }
				    	} //IF THERE IS A MEDIA ENTITY
		             }
		            else {
		            		DisplayTweet currentTweet = new DisplayTweet(tweets[y], LikeTweet(status), ViewTweet(status), RetweetIt(status), twitterProfileImage);
		            		if(status.isFavorited()) {
		            		 //currentTweet.getClientProperty(LikeTweet(status));
		            			currentTweet.getComponent(0).setBackground(Color.RED);
		            		
		            		}//if status is liked paint button pink/red	
		            		gbc.gridy = gbcCounter;
		            		mainView.add(currentTweet, gbc);
		            		gbcCounter++;
		            	}
				    	y++;      
		                System.out.println("@" + status.getUser().getScreenName() + " - " + status.getText());
		            	} // end of for
		            }
	               }
	            } else {
	                //pop out set users first
	            	 JFrame popup = new JFrame();
	            	 JOptionPane.showMessageDialog(popup, "You need to set up your favourite users first.");
	            }
	        } catch (TwitterException te) {
	            te.printStackTrace();
	            System.out.println("Failed to get timeline: " + te.getMessage());
	            System.exit(-1);
	        }
			mainView.revalidate();
			mainView.repaint();
	}
	
	
	//Gets favorite users from file
	public void getFavUsers(List<String> favUsernames) {
		try  
		{  
			  File myObj = new File("favUsers.txt");
		      if (!myObj.exists()) {
		    	  	JFrame jFrame = new JFrame();
					JOptionPane.showMessageDialog(jFrame, "List of Favourite users is empty.");
		      }
		      else {
		    	  	FileReader fr=new FileReader("favUsers.txt");   //reads the file  
					BufferedReader br=new BufferedReader(fr);  //creates a buffering character input stream  
					String line; 
					while((line=br.readLine())!=null)  
						{  
						//sb.append(line);      //appends line to string buffer  
						//sb.append("\n");     //line feed   
						favUsernames.add(line);
						
						}
					fr.close();   
					System.out.println(favUsernames.size());
		      }
		}catch(IOException e)  
			{  
			e.printStackTrace();  
			}  
		
	}
}
