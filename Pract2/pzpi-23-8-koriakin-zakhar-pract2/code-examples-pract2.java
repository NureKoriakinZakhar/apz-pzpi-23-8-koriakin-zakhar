1  import org.springframework.beans.factory.annotation.Autowired;
2  import org.springframework.web.bind.annotation.*;
3  import org.springframework.web.client.RestTemplate;
4  import io.github.resilience4j.circuitbreaker.annotation.CircuitBreaker;
5  import java.util.Arrays;
6  import java.util.List;
7  
8  @RestController
9  public class MovieCatalogService {
10 
11     @Autowired
12     private RestTemplate restTemplate;
13 
14     // Метод звертається до іншого (зовнішнього) мікросервісу
15     @GetMapping("/catalog/{userId}")
16     @CircuitBreaker(name = "recommendationService", fallbackMethod = "getFallbackCatalog")
17     public List<String> getCatalog(@PathVariable String userId) {
18         // Імітація виклику мікросервісу рекомендацій через мережу
19         return restTemplate.getForObject("http://recommendation-service/api/" + userId, List.class);
20     }
21 
22     // Fallback метод, який автоматично викликається при падінні recommendation-service
23     public List<String> getFallbackCatalog(String userId, Exception e) {
24         // Повертаємо закешований або дефолтний список контенту замість критичної помилки 500
25         return Arrays.asList("Базовий фільм 1", "Базовий фільм 2");
26     }
27 }

Запити до ШІ:
Згенеруй базовий приклад того, як працює API Gateway у поєднанні з Circuit Breaker (на прикладі Java/Spring Boot), який би демонстрував ізоляцію збоїв мікросервісу при взаємодії між компонентами;
Проведи порівняльний аналіз патернів Circuit Breaker та Retry у контексті мікросервісної архітектури. В яких саме сценаріях мережевої взаємодії доцільніше використовувати миттєве перемикання на fallback-логіку, а в яких повторні спроби запиту?
Поясни, як архітектурне впровадження патерну Circuit Breaker доповнює методологію Chaos Engineering (зокрема використання інструментів на кшталт Chaos Monkey від Netflix) при проєктуванні відмовостійких розподілених систем.
