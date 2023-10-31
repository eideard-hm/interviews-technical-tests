import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { catchError, throwError, type Observable } from 'rxjs';
import { environments } from 'src/environments/environments';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private readonly _http = inject(HttpClient);
  private readonly apiUrl = environments.API_URL;

  /**
   * Iniciar sesión
   * @param credentials
   * @returns
   */
  login(credentials: { email: string; password: string }): Observable<any> {
    return this._http.post(this.apiUrl, credentials).pipe(
      catchError(err => {
        console.error(err);
        return throwError(
          () => new Error('Algo salió mal al momento de realizar login')
        );
      })
    );
  }
}
