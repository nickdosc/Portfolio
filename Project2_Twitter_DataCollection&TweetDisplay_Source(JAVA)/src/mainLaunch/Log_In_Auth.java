package mainLaunch;


import java.awt.EventQueue;

import authLogin.authLog;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.SpringLayout;
import javax.swing.SwingConstants;
import javax.swing.JButton;
import java.awt.event.ActionListener;

import java.awt.event.ActionEvent;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import java.awt.FlowLayout;
import java.awt.GridBagLayout;
import java.awt.GridBagConstraints;
import java.awt.Insets;
import com.jgoodies.forms.layout.FormLayout;
import com.jgoodies.forms.layout.ColumnSpec;
import com.jgoodies.forms.layout.RowSpec;
import com.jgoodies.forms.layout.FormSpecs;

public class Log_In_Auth extends JFrame {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Log_In_Auth frame = new Log_In_Auth();
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
	public Log_In_Auth() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 712, 317);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		setLocationRelativeTo(null);
		setResizable(false);
		
		JButton authBtn = new JButton("Authorize");
		authBtn.setBounds(105, 131, 470, 44);
		authBtn.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				//action
				authLog.Authorize_User();
				dispose();
			}
		});
		contentPane.setLayout(null);
		contentPane.add(authBtn);
		
		JLabel authLabel = new JLabel("You need to authorize the application by pressing the button below.", SwingConstants.CENTER);
		authLabel.setBounds(105, 61, 470, 59);
		contentPane.add(authLabel);
	}
}
