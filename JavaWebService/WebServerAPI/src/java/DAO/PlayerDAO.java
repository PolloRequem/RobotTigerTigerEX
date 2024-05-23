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
}
