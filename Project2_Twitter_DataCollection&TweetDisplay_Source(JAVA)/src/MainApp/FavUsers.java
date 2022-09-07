package MainApp;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.GridBagConstraints;
import java.awt.Insets;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JScrollPane;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.awt.event.ActionEvent;
import java.awt.GridBagLayout;

public class FavUsers extends JFrame {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					FavUsers frame = new FavUsers();
					frame.setVisible(true);
					
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public FavUsers() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 600, 465);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		setLocationRelativeTo(null);
		contentPane.setLayout(null);
		
		JScrollPane scrollPane = new JScrollPane();
		scrollPane.setBounds(10, 11, 564, 278);
		contentPane.add(scrollPane);
		
		JPanel mainView = new JPanel();
		scrollPane.setViewportView(mainView);
		GridBagLayout gbl_mainView = new GridBagLayout();
		gbl_mainView.columnWidths = new int[]{0};
		gbl_mainView.rowHeights = new int[]{0};
		gbl_mainView.columnWeights = new double[]{Double.MIN_VALUE};
		gbl_mainView.rowWeights = new double[]{Double.MIN_VALUE};
		mainView.setLayout(gbl_mainView);
		
		JButton setFavUsers = new JButton("Save Users");
		setFavUsers.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				MainScreen log = new MainScreen();
				log.show(true);
				dispose();
			}
		});
		setFavUsers.setBounds(189, 300, 208, 65);
		contentPane.add(setFavUsers);
		
		JButton backBTN = new JButton("Back");
		backBTN.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				MainScreen log = new MainScreen();
				log.show(true);
				dispose();
			}
		});
		backBTN.setBounds(189, 377, 208, 38);
		contentPane.add(backBTN);
		
		JButton addUsersBTN = new JButton("Add Users");
		addUsersBTN.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				AddUsers();
				
			}
		});
		addUsersBTN.setBounds(24, 343, 135, 72);
		contentPane.add(addUsersBTN);
		
		JButton removeUsersBTN = new JButton("Remove Users");
		removeUsersBTN.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					RemoveUser();
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		removeUsersBTN.setBounds(439, 343, 135, 72);
		contentPane.add(removeUsersBTN);
		
		
		JButton refreshBTN = new JButton("Refresh");
		refreshBTN.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				ReadUsers(mainView);
				
			}
		});
		refreshBTN.setBounds(446, 300, 115, 29);
		contentPane.add(refreshBTN);
	}
	
	
	
	//Add users to the favourite timeline
	public void AddUsers() {
		String user = JOptionPane.showInputDialog("Enter the @ name of the user.");
		if (user.length() > 0) {
			
			try {
			      File myObj = new File("favUsers.txt");
			      if (myObj.createNewFile()) {
			        System.out.println("File created: " + myObj.getName());
			        FileWriter fw = new FileWriter("favUsers.txt", true);
			        BufferedWriter bw = new BufferedWriter(fw);
			        bw.write(user);
			        bw.newLine();
			        bw.close();
			       
			        
			      } else {
			        System.out.println("File already exists.");
			        FileWriter fw = new FileWriter("favUsers.txt", true);
			        BufferedWriter bw = new BufferedWriter(fw);
			        bw.write(user);
			        bw.newLine();
			        bw.close();
			     
			      }
			    } catch (IOException e) {
			      System.out.println("An error occurred.");
			      e.printStackTrace();
			    }
			
			
			
		}
		else {
			JFrame jFrame = new JFrame();
			JOptionPane.showMessageDialog(jFrame, "You need to input a username.");
		}
	}
	
	
	//Read the favourite users file
	public void ReadUsers(JPanel mainview) {
		try  
		{  
			  File myObj = new File("favUsers.txt");
		      if (!myObj.exists()) {
		    	  	JFrame jFrame = new JFrame();
					JOptionPane.showMessageDialog(jFrame, "List of Favourite users is empty.");
		      }
		      else {
		    	  	mainview.removeAll();
		    	  	mainview.revalidate();
					mainview.repaint();
		  	    	GridBagConstraints gbc = new GridBagConstraints();
		  	    	gbc.insets = new Insets(10,10,10,10);
		    	  	FileReader fr=new FileReader("favUsers.txt");   //reads the file  
					BufferedReader br=new BufferedReader(fr);  //creates a buffering character input stream  
					//StringBuffer sb=new StringBuffer();    //constructs a string buffer with no characters  
					List<String> usernames = new ArrayList<String>();
					String line; 

					while((line=br.readLine())!=null)  
						{  
						//sb.append(line);      //appends line to string buffer  
						//sb.append("\n");     //line feed   
						usernames.add(line);
						
						}
					fr.close();    //closes the stream and release the resources  
					//System.out.println("Contents of File: ");  
					//System.out.println(sb.toString());   //returns a string that textually represents the object  
					System.out.println(usernames.size());
					JLabel[] username = new JLabel[usernames.size()];
					for(int i = 0; i < usernames.size(); i++) {
						username[i] = new JLabel(usernames.get(i));
						gbc.gridy = i;
						username[i].setSize(3,3);
						username[i].setBounds(3,3,3,3);
						mainview.add(username[i], gbc);
					}
					mainview.revalidate();
					mainview.repaint();
		      }
		}
			catch(IOException e)  
			{  
				e.printStackTrace();  
			}  
		
	}
	
	
	//Search for User and Delete him
	public void RemoveUser() throws IOException {
		File myObj = new File("favUsers.txt");
		File mynewObj = new File("temp.txt");
	    if (!myObj.exists()) {
	    	  	JFrame jFrame = new JFrame();
				JOptionPane.showMessageDialog(jFrame, "List of Favourite users is empty.");
	      } 
	    else { 
		String user = JOptionPane.showInputDialog("Enter the @ name of the user.");
		if (user.length() > 0) {
		File file = new File("favUsers.txt");
		try {
			BufferedReader reader = new BufferedReader(new FileReader(file));
			BufferedWriter fw = new BufferedWriter(new FileWriter(mynewObj));
		    //now read the file line by line...
		    String line = null;
	        while ((line = reader.readLine()) != null) {
	            if (!line.equals(user)) {
	            	fw.write(line);
	            	fw.newLine();
	            }
	        }
		     fw.close();
		     reader.close();
		     
		     //Delete file and replace it
		     if (file.delete()) {
		         // Rename the output file to the input file
		         if (!mynewObj.renameTo(file)) {
		             throw new IOException("Could not rename " + mynewObj + " to " + file);
		         }
		     } else {
		         throw new IOException("Could not delete original input file " + file);
		     }
		 } catch(FileNotFoundException e) { 
		 			} 
		   }//End of if
	    }//End of Else file exists
	}//End of Class
	
	
	
	
}
