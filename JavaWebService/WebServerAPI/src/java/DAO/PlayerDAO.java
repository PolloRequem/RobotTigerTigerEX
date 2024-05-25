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
     public static List<Player> getListMissions() {
        
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
               
                elencoPlayer.add(new Player(id, userName, role, email));
 
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
     }

