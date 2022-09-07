package MainApp;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.URL;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.SwingConstants;

public class DisplayTweet extends JPanel {
	
	JLabel tweetText;
	JButton displayTweet;
	JLabel tweetImage;
	
	
	public DisplayTweet(JLabel tweetText, JButton displayTweet, JButton likeTweet, JButton retweetIt, URL profileImage) throws IOException {
		GridBagLayout gbl_DisplayTweet = new GridBagLayout();
		GridBagConstraints gbc = new GridBagConstraints();
		System.out.println(profileImage);
		BufferedImage image = ImageIO.read(profileImage);
		JLabel tweetProfileImageLabel = new JLabel(new ImageIcon(image));
		gbc.insets = new Insets(5,5,5,5);
		gbl_DisplayTweet.columnWidths = new int[]{0};
		gbl_DisplayTweet.rowHeights = new int[]{0};
		gbl_DisplayTweet.columnWeights = new double[]{Double.MIN_VALUE};
		gbl_DisplayTweet.rowWeights = new double[]{Double.MIN_VALUE};
		this.setLayout(gbl_DisplayTweet);
		
		int lines = 0;
		String[] words = tweetText.getText().split("\\s+");
		String[] properString = new String[words.length+1];
		String actualTweet = "<html>";
		for(int i =0; i < words.length; i++) {
			if(i<=10) {
				properString[i] = words[i];
			}
			if(i>10 && i<=20) {
				properString[11] = "line#";
				properString[i+1] = words[i];
			}
			if(i>20 && i<=30) {
				properString[21] = "line#";
				properString[i+1] = words[i];
			}
			if(i>30 && i<=40) {
				properString[31] = "line#";
				properString[i+1] = words[i];
			}
		}
		
		for(int i = 0; i<properString.length; i++) {
			if(properString[i] == "line#") {
				actualTweet = actualTweet + "<br>";
			} else {
				actualTweet = actualTweet + " " + properString[i];
			}
			
		}
		actualTweet = actualTweet + "</html>";
		tweetText.setText(actualTweet);
		System.out.println(tweetText.getText());
		
		
		this.setMinimumSize((new Dimension(600, 300)));
		this.setPreferredSize((new Dimension(600, 300)));
		this.setMaximumSize((new Dimension(600, 300)));
		this.setSize(600,300);
		this.setBounds(600,300,600,300);
		this.setBackground(Color.gray);
		
		
		tweetText.setPreferredSize((new Dimension(280, 150)));
		tweetText.setMinimumSize((new Dimension(280, 150)));
		tweetText.setMaximumSize((new Dimension(280, 150)));
		tweetText.setSize(280,150);
		tweetText.setBounds(280,150,280,150);
		
		
		
		displayTweet.setSize(5,5);
		displayTweet.setBounds(5,5,5,5);
		likeTweet.setSize(5,5);
		likeTweet.setBounds(5,5,5,5);
		retweetIt.setSize(5,5);
		retweetIt.setBounds(5,5,5,5);
		tweetProfileImageLabel.setSize(5,5);
		tweetProfileImageLabel.setBounds(10,10,10,10);
		gbc.gridy = 0;
		gbc.gridx = 0;
		this.add(tweetProfileImageLabel, gbc);
		//gbc.gridwidth = 1;
		gbc.gridx = 1;
		gbc.gridy = 0;
		gbc.gridwidth = 3;
		this.add(tweetText, gbc, SwingConstants.CENTER);
		gbc.gridy = 2;
		gbc.gridx = 0;
		gbc.gridwidth = 1;
		this.add(retweetIt, gbc, SwingConstants.CENTER);
		gbc.gridx = 1;
		this.add(likeTweet, gbc, SwingConstants.CENTER);
		gbc.gridx = 2;
		this.add(displayTweet, gbc, SwingConstants.CENTER);
		
		
	}
	
	
	
	public DisplayTweet(JLabel tweetText, JButton displayTweet, JButton likeTweet, JButton retweetIt, URL profileImage, URL tweetImage) throws IOException {
		GridBagLayout gbl_DisplayTweet = new GridBagLayout();
		GridBagConstraints gbc = new GridBagConstraints();
		BufferedImage image = ImageIO.read(tweetImage);
		JLabel tweetImageLabel = new JLabel(new ImageIcon(image));
		BufferedImage image2 = ImageIO.read(profileImage);
		JLabel tweetProfileImageLabel = new JLabel(new ImageIcon(image2));
		gbc.insets = new Insets(5,5,5,5);
		gbl_DisplayTweet.columnWidths = new int[]{0};
		gbl_DisplayTweet.rowHeights = new int[]{0};
		gbl_DisplayTweet.columnWeights = new double[]{Double.MIN_VALUE};
		gbl_DisplayTweet.rowWeights = new double[]{Double.MIN_VALUE};
		this.setLayout(gbl_DisplayTweet);
		
		
		
		this.setBounds(15,15,15,15);
		this.setBackground(Color.gray);
		
		tweetText.setSize(3,3);
		tweetText.setBounds(10,10,10,10);
		tweetImageLabel.setSize(5,5);
		tweetImageLabel.setBounds(10,10,10,10);
		displayTweet.setSize(5,5);
		displayTweet.setBounds(5,5,5,5);
		likeTweet.setSize(5,5);
		likeTweet.setBounds(5,5,5,5);
		retweetIt.setSize(5,5);
		retweetIt.setBounds(5,5,5,5);
		tweetProfileImageLabel.setSize(5,5);
		tweetProfileImageLabel.setBounds(10,10,10,10);
		gbc.gridx = 0;
		gbc.gridy = 1;
		this.add(tweetProfileImageLabel, gbc, SwingConstants.CENTER);
		gbc.gridx = 1;
		this.add(tweetText, gbc);
		gbc.gridy = 2;
		this.add(tweetImageLabel,gbc);
		gbc.gridy = 3;
		gbc.gridx = 1;
		this.add(retweetIt, gbc);
		gbc.gridx = 2;
		this.add(likeTweet, gbc);
		gbc.gridx = 3;
		this.add(displayTweet, gbc);
	}

}
