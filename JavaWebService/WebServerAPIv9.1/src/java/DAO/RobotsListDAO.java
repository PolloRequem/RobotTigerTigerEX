/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package DAO;

import Bean.Robot;
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
public class RobotsListDAO {
    
    
     public static String addRobots(String nome,String seriale, String nPorte,String nRuote){
    Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return "Error#1 Connection to server faild";
        }

        PreparedStatement ps;
        try {
          
            ps = cn.prepareStatement("select nome from robots where seriale=?");
            ps.setString(1, seriale);
    
            ResultSet rs = ps.executeQuery();
            if(rs.next()){
                
                return "Error#3 There is  already a robot whit this serial";
            }
             ps = cn.prepareStatement("select nome from players where nome=?");
            ps.setString(1, nome);
    
            rs = ps.executeQuery();
            if(rs.next()){
                
                return "Error#3 Name already in use.";
            }
            
            
            PreparedStatement pst = cn.prepareStatement("INSERT INTO robots(nome,seriale,nPorte,nRuote) VALUES(?,?,?,?);");
            pst.setString(1, nome);
            pst.setString(2, seriale);
            pst.setString(3, nPorte);
            pst.setString(4, nRuote);
         
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
    public static List<Robot> getListRobots() {
        List<Robot> robots = new ArrayList<>();
        Connection cn = ConnectionDataBase.getConnection();
        
        if (cn == null) {
            return null;
        }
        PreparedStatement ps;
        try {
            
            ps = cn.prepareStatement("select nome,seriale,nPorte,nRuote from robots");
            
            ResultSet rs = ps.executeQuery();
            
            while (rs.next()) {
                String name = rs.getString("nome");
                int seriale = rs.getInt("seriale");
                int nPorte = rs.getInt("nPorte");
                int nRuote =rs.getInt("nRuote");
                robots.add(new Robot(name, seriale, nPorte, nRuote));
            }
            
            return robots;
            
        } catch (SQLException ex) {
            return null;
            
        }
        
    }
}
