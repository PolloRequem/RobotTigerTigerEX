/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package DAO;


import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.util.Base64;

/**
 *
 * @author baiunco.dante
 */
public class RegistraDAO {
private  static final int SALT_LENGTH = 16;
    public static String addUser(String email, String username,String password) {
        Connection cn = ConnectionDataBase.getConnection();
        byte[] salt = generateSalt();
        String saltSTRING = Base64.getEncoder().encodeToString(salt);
        String saltedPassword = password + saltSTRING;
        String hashedPassword = hashPassword(saltedPassword);
        
     
       
        if (cn == null) {
            return "Error#1 Connection to server faild";
        }

        PreparedStatement ps;
        try {
          
            ps = cn.prepareStatement("select id from players where username=?");
            ps.setString(1, username);
    
            ResultSet rs = ps.executeQuery();
            if(rs.next()){
                
                return "Error#3 Username already exists.";
            }
             ps = cn.prepareStatement("select id from players where email=?");
            ps.setString(1, email);
    
            rs = ps.executeQuery();
            if(rs.next()){
                
                return "Error#3 Email already in use.";
            }
            
            
            PreparedStatement pst = cn.prepareStatement("INSERT INTO players(email,username,hash,salt) VALUES(?,?,?,?);");
            pst.setString(1, email);
            pst.setString(2, username);
            pst.setString(3, hashedPassword);
            pst.setString(4, saltSTRING);
         
           if(pst.executeUpdate()==1){
               return "1";
           }
           else{
               return "Errore#4 Data insertion error. Please try again later.";
           }
          
        } catch (SQLException ex) {
            return "Error#2 SQL exception:  "+ ex.toString();

        }
    } 
      private static  byte[] generateSalt() {
        SecureRandom random = new SecureRandom();
        byte[] salt = new byte[SALT_LENGTH];
        random.nextBytes(salt);
        return salt;
    }
     private static String hashPassword(String password) {
        try {
            MessageDigest md = MessageDigest.getInstance("SHA-256");
            byte[] hashedBytes = md.digest(password.getBytes());
            return Base64.getEncoder().encodeToString(hashedBytes);
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
            return null;
        }
     }
}
