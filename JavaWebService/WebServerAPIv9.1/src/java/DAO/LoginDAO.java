/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package DAO;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.sql.*;
import java.util.Base64;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author baiunco.dante
 */
public class LoginDAO {

    private static final int SALT_LENGTH = 16;

    public static String checkLogin(String username, String password) {
        Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return "Error#1 Connection to server faild";
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("select username,hash,salt,role from players where username=?");
            ps.setString(1, username);

            ResultSet rs = ps.executeQuery();
            if (!rs.next()) {

                return "Error#5 Wrong password or username";
            }

            String hash = rs.getString(2);
            String salt = password + rs.getString(3);
            String userHash = hashPassword(salt);

            
            if (!hash.equals(userHash)) {
                return "Error#6 Wrong password or username";
            }
            
           
            return "1";

        } catch (SQLException ex) {
            return "Error#2 SQL exception:  " + ex.toString();

        }
    }

    private static byte[] generateSalt() {
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
