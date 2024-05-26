/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package DAO;

import Bean.Mission;
import Bean.Ritrovamenti;
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
public class RitrovamentiDAO {
    
    public static List<Ritrovamenti> getListRitrovamenti() {
   
        List<Ritrovamenti> elencoRitrovamenti = new ArrayList<>();
        Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return null;
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("select * from ritrovamenti");

            ResultSet rs = ps.executeQuery();
           
            while (rs.next()) {
                String missione = rs.getString("missione");
                int materiale = rs.getInt("materiale");
                String dataInizio = rs.getString("dataInizio");
                double parziali = rs.getDouble("parziali");
             
                elencoRitrovamenti.add(new Ritrovamenti(missione, materiale, dataInizio, parziali));
            }

            return elencoRitrovamenti;

        } catch (SQLException ex) {
            return null;

        }

    }
     public static List<Ritrovamenti> getListRitrovamentiByMissionID(String missionID) {
        
        List<Ritrovamenti> elencoRitrovamenti = new ArrayList<>();
        Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return null;
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("select * from ritrovamenti WHERE missione =?");
            ps.setString(1, missionID);
            ResultSet rs = ps.executeQuery();
           
            while (rs.next()) {
                String missione = rs.getString("missione");
                int materiale = rs.getInt("materiale");
                String dataInizio = rs.getString("dataInizio");
                double parziali = rs.getDouble("parziali");
             
                elencoRitrovamenti.add(new Ritrovamenti(missione, materiale, dataInizio, parziali));
            }

            return elencoRitrovamenti;

        } catch (SQLException ex) {
            return null;

        }

    }
     
      public static String addRitrovamenti(String missione,int materiale,String data,int parziali){
    Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return  "Error#1 Connection to server faild";
        }

        PreparedStatement ps;
        try {
          
            
            PreparedStatement pst = cn.prepareStatement("INSERT INTO ritrovamenti(missione,materiale,dataInizio,parziali) VALUES(?,?,?,?);");
            pst.setString(1, missione);
            pst.setInt(2, materiale);
            pst.setString(3, data);
            pst.setInt(4, parziali);
         
           if(pst.executeUpdate()==1){
               return   "1";// "Mission Started!";
           }
           else{
               return  "Errore#4 Data insertion error. Please try again later.";
           }
          
        } catch (SQLException ex) {
            return "Error#2 SQL exception:  "+ ex.toString();

        }
    } 
}

