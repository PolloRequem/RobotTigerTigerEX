/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package DAO;

import Bean.Player;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Dante
 */
public class PlayerDAO {
     public static Player getPlayer(String username) {
        
       
        Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return null;
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("select * from players WHERE username = ?");
            ps.setString(1, username);
            ResultSet rs = ps.executeQuery();
           
            if(rs.next()) {
                int id = rs.getInt("id");
                String userName = rs.getString("username");
                String role = rs.getString("role");
                String email= rs.getString("email");
                int totalPoints = rs.getInt("TotalPoints");
                int missionsCompleted = rs.getInt("missionsCompleted");
               
              return new Player(id, userName, role, email, totalPoints ,missionsCompleted);
 
            }

            return null;

        } catch (SQLException ex) {
            return null;

        }

    }
     public static List<Player> getListPlayers() {
        
        List<Player> elencoPlayer = new ArrayList<>();
        Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return null;
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("select * from players");

            ResultSet rs = ps.executeQuery();
           
            while (rs.next()) {
                int id = rs.getInt("id");
                String userName = rs.getString("username");
                String role = rs.getString("role");
                String email= rs.getString("email");
                int totalPoints = rs.getInt("TotalPoints");
                int missionsCompleted = rs.getInt("missionsCompleted");
               
                elencoPlayer.add(new Player(id, userName, role, email, totalPoints ,missionsCompleted));
 
            }

            return elencoPlayer; 

        } catch (SQLException ex) {
            return null;

        }

    }
     
     public static String deletePlayer(String id){
         Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return null;
        }
          PreparedStatement ps;
        try {

            ps = cn.prepareStatement("DELETE FROM `players` WHERE id=?");
            ps.setString(1, id);
    
            ResultSet rs = ps.executeQuery();
        

            return "ok"; 

        } catch (SQLException ex) {
            return null;

        }
     }
     
     public static String modifyPlayer(int id , String username ,String role, String email){
         
 Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return "Connection Lost";
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("UPDATE `players` SET `id`=?, `username`=?,`role`=?,`email`=?  WHERE id=?");

            ps.setInt(1, id);
            ps.setString(2, username);
            ps.setString(3, role);
            ps.setString(4, email);
            ps.setInt(5, id);

            if (ps.executeUpdate() == 1) {
                return "1";
            } else {
                return "Errore#4 Data insertion error. Please try again later.";
            }

        } catch (SQLException ex ) {
            return "2";

        }
    }
     
         public static String addPointsPlayer(int id , int totalPoints , int missionsCompleted){
        
    Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return "Connection Lost";
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("UPDATE `players` SET  `missionsCompleted`=? ,`totalPoints`= ?   WHERE id=?");

            ps.setInt(1, missionsCompleted);
            ps.setInt(2, totalPoints);
            ps.setInt(3, id);

            if (ps.executeUpdate() == 1) {
                return "1";
            } else {
                return "Errore#4 Data insertion error. Please try again later.";
            }

        } catch (SQLException ex ) {
            return ex.toString();

        }
    }
     }
     

