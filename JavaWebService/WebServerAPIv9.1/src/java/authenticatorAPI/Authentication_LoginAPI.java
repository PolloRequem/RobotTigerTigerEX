/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package authenticatorAPI;

import DAO.LoginDAO;
import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.core.Form;

/**
 *
 * @author Dante
 */
@Path("login")
public class Authentication_LoginAPI {
    
    
    @POST
    @Consumes("application/x-www-form-urlencoded")
    public String checkLogin(Form form) {
        try {
            String username = form.asMap().getFirst("username");
            String password = form.asMap().getFirst("password");
            
          
       
            return  LoginDAO.checkLogin(username, password);
        } catch (Exception e) {
            return "Errore nella API";
        }
    }
}
