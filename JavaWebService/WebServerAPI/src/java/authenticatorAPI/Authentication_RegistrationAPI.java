/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package authenticatorAPI;

import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.QueryParam;
import jakarta.ws.rs.core.Form;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import DAO.RegistraDAO;

/**
 *
 * @author baiunco.dante
 */
@Path("registration")
public class Authentication_RegistrationAPI {

  
    
    @POST
    @Consumes("application/x-www-form-urlencoded")
    public String addPlayer(Form form) {
        try {
            String username = form.asMap().getFirst("username");
            String email = form.asMap().getFirst("email");
            String password = form.asMap().getFirst("password");
            
        
       
            return  RegistraDAO.addUser(email, username, password);
        } catch (Exception e) {
            return "Errore nella API";
        }
    }
}
