package mainLaunch;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

import MainApp.MainScreen;

import javax.swing.JLabel;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.SpringLayout;
import java.awt.event.ActionListener;
import java.io.File;
import java.awt.event.ActionEvent;

public class Start_UI_Log extends JFrame {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Start_UI_Log frame = new Start_UI_Log();
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
	public Start_UI_Log() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 670, 557);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		setLocationRelativeTo(null);
		contentPane.setLayout(null);
		setResizable(false);
		
		JLabel LogoFrame = new JLabel("");
		LogoFrame.setBounds(111, 15, 442, 325);
		LogoFrame.setIcon(new ImageIcon(Start_UI_Log.class.getResource("/imgRes/rsz_Logo.png")));
		contentPane.add(LogoFrame);
		
		JButton btnNewButton = new JButton("Log In");
		btnNewButton.setBounds(236, 385, 175, 53);
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				File myObj = new File("twitter4j.properties");
			     if (myObj.exists()) {
			    	 MainScreen mainview = new MainScreen();
			    	 mainview.show(true);
			    	 dispose();
			     }
			     else {
			    		Log_In_Auth log = new Log_In_Auth();
						log.show(true);
						dispose();
			     }
			
			}
		});
		contentPane.add(btnNewButton);
	}
}
