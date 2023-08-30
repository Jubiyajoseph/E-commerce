import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit{


  constructor(private loginService: LoginService,private fb: FormBuilder,private router: Router)
  {  
  }

  showErrors = false;

  loginForm = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl('')
  });

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      userName: new FormControl('',[Validators.required]),
      password: new FormControl('',[Validators.minLength(6),Validators.required])
    })
  }

  onClickLogin()
  {
    const username =this.loginForm.get('userName')?.value!;
    const password =this.loginForm.get('password')?.value!;

    this.loginService.Login(username,password).subscribe(
      ()=>{
        this.router.navigate(['/home']);
       }
    //,
    //   error=> {
    //     alert('Insert valid Username or Password')
    //   }
     );
  }

}
