/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package DAO;

import Bean.Mission;
import Bean.Robot;
import Bean.Seriale_Mission;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Base64;
import java.util.List;

/**
 *
 * @author Dante
 */
public class MissionListDAO {
    
  public static String addMission(String id,String nome, String robot,String player){
    Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return  "Error#1 Connection to server faild";
        }

        PreparedStatement ps;
        try {
          
            ps = cn.prepareStatement("select * from missions where id=?");
            ps.setString(1, id);
    
            ResultSet rs = ps.executeQuery();
            if(rs.next()){
                
                return   "Error#3 ID already in use ";
            }
             ps = cn.prepareStatement("select * from missions where nome=?");
            ps.setString(1, nome);
    
            rs = ps.executeQuery();
            if(rs.next()){
                
                return   "Error#6 Name already in use.";
            }
            
            
            PreparedStatement pst = cn.prepareStatement("INSERT INTO missions(id,nome,robot,player) VALUES(?,?,?,?);");
            pst.setString(1, id);
            pst.setString(2, nome);
            pst.setString(3, robot);
            pst.setString(4, player);
         
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
    
    public static List<Mission> getListMissions() {
        
        List<Mission> elencoMisisoni = new ArrayList<>();
        Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return null;
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("select * from missions");

            ResultSet rs = ps.executeQuery();
           
            while (rs.next()) {
                String seriale = rs.getString("id");
                String nome = rs.getString("nome");
                String robot = rs.getString("robot");
                String dataInizio = rs.getString("dataInizio");
                String dataFine = rs.getString("dataFine");
               
                int punteggio = rs.getInt("punteggio");
                String player = rs.getString("player");
                
 
             elencoMisisoni.add(new Mission(seriale, punteggio,  nome, robot, dataInizio, dataFine, player));
            }

            return elencoMisisoni; 

        } catch (SQLException ex) {
            return null;

        }

    }
    
    public static String checkMissionID(String missionID){
        Connection cn = ConnectionDataBase.getConnection();
        
         if (cn == null) {
            return "Error#1 Connecction feild";
        }
         PreparedStatement ps;
        try {

            ps = cn.prepareStatement("select id from missions where id=?");
            ps.setString(1, missionID);

            ResultSet rs = ps.executeQuery();
            if (!rs.next()) {

                return "Error#5 This id is already in use";
            }
            
            return "1";
         } catch (SQLException ex) {
            return "Error#2 SQL exception:  " + ex.toString();

        }
    }
    
    
    public static List<String> getListSerialiMissions() {
        
        List<String> serialiMisisoni = new ArrayList<>();
        Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return null;
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("select id from missions");

            ResultSet rs = ps.executeQuery();
           
            while (rs.next()) {
                String seriale = rs.getString("id");
                serialiMisisoni.add(seriale);
       
            }

            return serialiMisisoni; 

        } catch (SQLException ex) {
            return null;

        }

    }
    
         public static String completeMissions(String id , int punteggio, String dataFine){
        
    Connection cn = ConnectionDataBase.getConnection();

        if (cn == null) {
            return "Connection Lost";
        }
        PreparedStatement ps;
        try {

            ps = cn.prepareStatement("UPDATE `missions` SET  `punteggio`=?  ,`dataFine`=?  WHERE id=?");

              ps.setInt(1, punteggio);
            ps.setString(2, dataFine);
           
            ps.setString(3,  id);

            if (ps.executeUpdate() == 1) {
                return "1";
            } else {
                return "Errore#4 Data insertion error. Please try again later.";
            }

        } catch (Exception ex ) {
            return ex.toString();

        }
    }
}
